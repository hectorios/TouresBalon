﻿using System.Threading.Tasks;
using SimplCommerce.Infrastructure;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Areas.Orders.ViewModels;
using SimplCommerce.Module.Orders.Models;

namespace SimplCommerce.Module.Orders.Services
{
    public interface IOrderService
    {
        Task<Result<Order>> CreateOrder(long cartId, string paymentMethod, OrderStatus orderStatus = OrderStatus.New);

        Task<Result<Order>> CreateOrder(long cartId, string paymentMethod, Address billingAddress, OrderStatus orderStatus = OrderStatus.New);

        void CancelOrder(Order order);

        Task<OrderTaxAndShippingPriceVm> UpdateTaxAndShippingPrices(long cartId, TaxAndShippingPriceRequestVm model);
    }
}
