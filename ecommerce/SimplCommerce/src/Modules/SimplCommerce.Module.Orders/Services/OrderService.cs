using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Areas.Orders.ViewModels;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.Orders.Events;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly ICouponService _couponService;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly ICartService _cartService;
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly IMediator _mediator;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<Cart> cartRepository,
            ICouponService couponService,

            IRepository<CartItem> cartItemRepository,
            IRepository<OrderItem> orderItemRepository,
            ICartService cartService,
            IRepository<UserAddress> userAddressRepository,
            IMediator mediator)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _couponService = couponService;
            _cartItemRepository = cartItemRepository;
            _orderItemRepository = orderItemRepository;
            _cartService = cartService;
            _userAddressRepository = userAddressRepository;
            _mediator = mediator;
        }

        public async Task<Result<Order>> CreateOrder(long cartId, string paymentMethod, decimal paymentFeeAmount, OrderStatus orderStatus = OrderStatus.Nueva)
        {
            var cart = await _cartRepository
               .Query()
               .Where(x => x.Id == cartId).FirstOrDefaultAsync();

            if (cart == null)
            {
                return Result.Fail<Order>($"Cart id {cartId} cannot be found");
            }

            var shippingData = JsonConvert.DeserializeObject<DeliveryInformationVm>(cart.ShippingData);
            Address billingAddress;
            Address shippingAddress;
            if (shippingData.ShippingAddressId == 0)
            {
                var address = new Address
                {
                    AddressLine1 = shippingData.NewAddressForm.AddressLine1,
                    AddressLine2 = shippingData.NewAddressForm.AddressLine2,
                    ContactName = shippingData.NewAddressForm.ContactName,
                    CountryId = shippingData.NewAddressForm.CountryId,
                    StateOrProvinceId = shippingData.NewAddressForm.StateOrProvinceId,
                    DistrictId = shippingData.NewAddressForm.DistrictId,
                    City = shippingData.NewAddressForm.City,
                    ZipCode = shippingData.NewAddressForm.ZipCode,
                    Phone = shippingData.NewAddressForm.Phone
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    AddressType = AddressType.Shipping,
                    UserId = cart.CustomerId
                };

                _userAddressRepository.Add(userAddress);

                shippingAddress = address;
            }
            else
            {
                shippingAddress = _userAddressRepository.Query().Where(x => x.Id == shippingData.ShippingAddressId).Select(x => x.Address).First();
            }

            if (shippingData.UseShippingAddressAsBillingAddress)
            {
                billingAddress = shippingAddress;
            }
            else if (shippingData.BillingAddressId == 0)
            {
                var address = new Address
                {
                    AddressLine1 = shippingData.NewBillingAddressForm.AddressLine1,
                    AddressLine2 = shippingData.NewBillingAddressForm.AddressLine2,
                    ContactName = shippingData.NewBillingAddressForm.ContactName,
                    CountryId = shippingData.NewBillingAddressForm.CountryId,
                    StateOrProvinceId = shippingData.NewBillingAddressForm.StateOrProvinceId,
                    DistrictId = shippingData.NewBillingAddressForm.DistrictId,
                    City = shippingData.NewBillingAddressForm.City,
                    ZipCode = shippingData.NewBillingAddressForm.ZipCode,
                    Phone = shippingData.NewBillingAddressForm.Phone
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    AddressType = AddressType.Billing,
                    UserId = cart.CustomerId
                };

                _userAddressRepository.Add(userAddress);

                billingAddress = address;
            }
            else
            {
                billingAddress = _userAddressRepository.Query().Where(x => x.Id == shippingData.BillingAddressId).Select(x => x.Address).First();
            }

            return await CreateOrder(cartId, paymentMethod, paymentFeeAmount, shippingData.ShippingMethod, billingAddress, shippingAddress, orderStatus);
        }

        public async Task<Result<Order>> CreateOrder(long cartId, string paymentMethod, decimal paymentFeeAmount, string shippingMethodName, Address billingAddress, Address shippingAddress, OrderStatus orderStatus = OrderStatus.Nueva)
        {
            var cart = _cartRepository
                .Query()
                .Include(c => c.Items).ThenInclude(x => x.Product)
                .Include(c => c.Customer)
                .Include(c => c.CreatedBy)
                .Where(x => x.Id == cartId).FirstOrDefault();

            if (cart == null)
            {
                return Result.Fail<Order>($"Cart id {cartId} cannot be found");
            }

            var checkingDiscountResult = await CheckForDiscountIfAny(cart);
            if (!checkingDiscountResult.Succeeded)
            {
                return Result.Fail<Order>(checkingDiscountResult.ErrorMessage);
            }

            var orderBillingAddress = new OrderAddress()
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                ContactName = billingAddress.ContactName,
                CountryId = billingAddress.CountryId,
                StateOrProvinceId = billingAddress.StateOrProvinceId,
                DistrictId = billingAddress.DistrictId,
                City = billingAddress.City,
                ZipCode = billingAddress.ZipCode,
                Phone = billingAddress.Phone
            };

            var orderShippingAddress = new OrderAddress()
            {
                AddressLine1 = shippingAddress.AddressLine1,
                AddressLine2 = shippingAddress.AddressLine2,
                ContactName = shippingAddress.ContactName,
                CountryId = shippingAddress.CountryId,
                StateOrProvinceId = shippingAddress.StateOrProvinceId,
                DistrictId = shippingAddress.DistrictId,
                City = shippingAddress.City,
                ZipCode = shippingAddress.ZipCode,
                Phone = shippingAddress.Phone
            };

            var order = new Order
            {
                Customer = cart.Customer,
                CreatedOn = DateTimeOffset.Now,
                CreatedBy = cart.CreatedBy,
                LatestUpdatedOn = DateTimeOffset.Now,
                LatestUpdatedById = cart.CreatedById,
                BillingAddress = orderBillingAddress,
                ShippingAddress = orderShippingAddress,
                PaymentMethod = paymentMethod,
                PaymentFeeAmount = paymentFeeAmount
            };

            foreach (var cartItem in cart.Items)
            {
                if (!cartItem.Product.IsAllowToOrder || !cartItem.Product.IsPublished || cartItem.Product.IsDeleted)
                {
                    return Result.Fail<Order>($"The product {cartItem.Product.Name} is not available any more");
                }

                if (cartItem.Product.StockTrackingIsEnabled && cartItem.Product.StockQuantity < cartItem.Quantity)
                {
                    return Result.Fail<Order>($"There are only {cartItem.Product.StockQuantity} items available for {cartItem.Product.Name}");
                }

                var productPrice = cartItem.Product.Price;

                var orderItem = new OrderItem
                {
                    Product = cartItem.Product,
                    ProductPrice = productPrice,
                    Quantity = cartItem.Quantity
                };

                var discountedItem = checkingDiscountResult.DiscountedProducts.FirstOrDefault(x => x.Id == cartItem.ProductId);
                if (discountedItem != null)
                {
                    orderItem.DiscountAmount = discountedItem.DiscountAmount;
                }

                order.AddOrderItem(orderItem);
                if (cartItem.Product.StockTrackingIsEnabled)
                {
                    cartItem.Product.StockQuantity = cartItem.Product.StockQuantity - cartItem.Quantity;
                }
            }

            order.OrderStatus = orderStatus;
            order.OrderNote = cart.OrderNote;
            order.CouponCode = checkingDiscountResult.CouponCode;
            order.CouponRuleName = cart.CouponRuleName;
            order.DiscountAmount = checkingDiscountResult.DiscountAmount;
            order.TaxAmount = order.OrderItems.Sum(x => x.TaxAmount);
            order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
            order.SubTotalWithDiscount = order.SubTotal - checkingDiscountResult.DiscountAmount;
            order.OrderTotal = order.SubTotal + order.TaxAmount + order.ShippingFeeAmount + order.PaymentFeeAmount - order.DiscountAmount;
            _orderRepository.Add(order);

            cart.IsActive = false;

            var vendorIds = cart.Items.Where(x => x.Product.VendorId.HasValue).Select(x => x.Product.VendorId.Value).Distinct();
            if (vendorIds.Any())
            {
                order.IsMasterOrder = true;
            }

            IList<Order> subOrders = new List<Order>();
            foreach (var vendorId in vendorIds)
            {
                var subOrder = new Order
                {
                    CustomerId = cart.CustomerId,
                    CreatedOn = DateTimeOffset.Now,
                    CreatedById = cart.CreatedById,
                    LatestUpdatedOn = DateTimeOffset.Now,
                    LatestUpdatedById = cart.CreatedById,
                    BillingAddress = orderBillingAddress,
                    ShippingAddress = orderShippingAddress,
                    VendorId = vendorId,
                    Parent = order
                };

                foreach (var cartItem in cart.Items.Where(x => x.Product.VendorId == vendorId))
                {

                    var productPrice = cartItem.Product.Price;

                    var orderItem = new OrderItem
                    {
                        Product = cartItem.Product,
                        ProductPrice = productPrice,
                        Quantity = cartItem.Quantity
                    };

                    if (cart.IsProductPriceIncludeTax)
                    {
                        orderItem.ProductPrice = orderItem.ProductPrice - orderItem.TaxAmount;
                    }

                    subOrder.AddOrderItem(orderItem);
                }

                subOrder.SubTotal = subOrder.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
                subOrder.TaxAmount = subOrder.OrderItems.Sum(x => x.TaxAmount);
                subOrder.OrderTotal = subOrder.SubTotal + subOrder.TaxAmount + subOrder.ShippingFeeAmount - subOrder.DiscountAmount;
                _orderRepository.Add(subOrder);
                subOrders.Add(subOrder);
            }

            using (var transaction = _orderRepository.BeginTransaction())
            {
                _orderRepository.SaveChanges();
                await _mediator.Publish(new OrderCreated(order));
                foreach (var subOrder in subOrders)
                {
                    await _mediator.Publish(new OrderCreated(subOrder));
                }

                _couponService.AddCouponUsage(cart.CustomerId, order.Id, checkingDiscountResult);
                _orderRepository.SaveChanges();
                transaction.Commit();
            }

            await _mediator.Publish(new AfterOrderCreated(order));

            return Result.Ok(order);
        }

        public void CancelOrder(Order order)
        {
            order.OrderStatus = OrderStatus.Cancelada;
            order.LatestUpdatedOn = DateTimeOffset.Now;

            var orderItems = _orderItemRepository.Query().Include(x => x.Product).Where(x => x.Order.Id == order.Id);
            foreach (var item in orderItems)
            {
                if (item.Product.StockTrackingIsEnabled)
                {
                    item.Product.StockQuantity = item.Product.StockQuantity + item.Quantity;
                }
            }
        }

        public async Task<OrderTaxAndShippingPriceVm> UpdateTaxAndShippingPrices(long cartId, TaxAndShippingPriceRequestVm model)
        {
            var cart = await _cartRepository.Query().FirstOrDefaultAsync(x => x.Id == cartId);
            if (cart == null)
            {
                throw new ApplicationException($"Cart id {cartId} not found");
            }

            Address address;
            if (model.ExistingShippingAddressId != 0)
            {
                address = await _userAddressRepository.Query().Where(x => x.Id == model.ExistingShippingAddressId).Select(x => x.Address).FirstOrDefaultAsync();
                if (address == null)
                {
                    throw new ApplicationException($"Address id {model.ExistingShippingAddressId} not found");
                }
            }
            else
            {
                address = new Address
                {
                    CountryId = model.NewShippingAddress.CountryId,
                    StateOrProvinceId = model.NewShippingAddress.StateOrProvinceId,
                    DistrictId = model.NewShippingAddress.DistrictId,
                    ZipCode = model.NewShippingAddress.ZipCode,
                    AddressLine1 = model.NewShippingAddress.AddressLine1,
                };
            }

            var orderTaxAndShippingPrice = new OrderTaxAndShippingPriceVm
            {
                Cart = await _cartService.GetActiveCartDetails(cart.CustomerId, cart.CreatedById)
            };

            await _cartRepository.SaveChangesAsync();
            return orderTaxAndShippingPrice;
        }

        private async Task<CouponValidationResult> CheckForDiscountIfAny(Cart cart)
        {
            if (string.IsNullOrWhiteSpace(cart.CouponCode))
            {
                return new CouponValidationResult { Succeeded = true, DiscountAmount = 0 };
            }

            var cartInfoForCoupon = new CartInfoForCoupon
            {
                Items = cart.Items.Select(x => new CartItemForCoupon { ProductId = x.ProductId, Quantity = x.Quantity }).ToList()
            };

            var couponValidationResult = await _couponService.Validate(cart.CustomerId, cart.CouponCode, cartInfoForCoupon);
            return couponValidationResult;
        }

    }
}
