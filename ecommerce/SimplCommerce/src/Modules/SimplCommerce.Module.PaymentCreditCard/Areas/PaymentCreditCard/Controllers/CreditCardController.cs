using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.PaymentCreditCard.Models;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.ShoppingCart.Areas.ShoppingCart.ViewModels;
using SimplCommerce.Module.ShoppingCart.Services;
using CreditCardValidation;
using System.Net.Http;


namespace SimplCommerce.Module.PaymentCreditCard.Areas.PaymentCreditCard.Controllers
{
    [Authorize]
    [Area("PaymentCreditCard")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CreditCardController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IWorkContext _workContext;
        private readonly ICartService _cartService;
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private Lazy<CreditCardSetting> _setting;

        public CreditCardController(
            ICartService cartService,
            IOrderService orderService,
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IWorkContext workContext)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _cartService = cartService;
            _orderService = orderService;
            _workContext = workContext;
            _setting = new Lazy<CreditCardSetting>(GetSetting());
        }

        public async Task<IActionResult> CreditCardCheckout()
        {
            string creditCardNumber = Request.Form["ccnumber"];
            var currentUser = await _workContext.GetCurrentUser();
            var cart = await _cartService.GetActiveCartDetails(currentUser.Id);
            if(cart == null)
            {
                return NotFound();
            }

            if (!ValidateCreditCard(creditCardNumber))
            {
                TempData["Error"] = "Los datos de la tarjeta no pudieron ser validados, por favor intente nuevamente";
                return Redirect("~/checkout/payment");
            }

            var orderCreateResult = await _orderService.CreateOrder(cart.Id, "CreditCard", 0);

            if (!orderCreateResult.Success)
            {
                TempData["Error"] = orderCreateResult.Error;
                return Redirect("~/checkout/payment");
            }
            else
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://10.39.1.200:8081/esb/"+ orderCreateResult.Value.Id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }

            return Redirect($"~/checkout/success?orderId={orderCreateResult.Value.Id}");
        }

        private CreditCardSetting GetSetting()
        {
            var coDProvider = _paymentProviderRepository.Query().FirstOrDefault(x => x.Id == PaymentProviderHelper.CreditCardProviderId);
            if (string.IsNullOrEmpty(coDProvider.AdditionalSettings))
            {
                return new CreditCardSetting();
            }

            var coDSetting = JsonConvert.DeserializeObject<CreditCardSetting>(coDProvider.AdditionalSettings);
            return coDSetting;
        }

        private bool ValidateCreditCard(String creditCardNumber)
        {

            CreditCardValidation.getCreditCardValidationRequest requestVal = new CreditCardValidation.getCreditCardValidationRequest();
            requestVal.number = creditCardNumber;

            CreditCardValidation.getCreditCardValidationRequest1 ValidateCardNumber = new CreditCardValidation.getCreditCardValidationRequest1(requestVal);

            Task<getCreditCardValidationResponse1> responseVal;

            CreditCardValidation.CountriesPortClient validation = new CreditCardValidation.CountriesPortClient();
            responseVal = validation.getCreditCardValidationAsync(requestVal);
            Console.WriteLine("ESTA ES LA RESPUESTA" + responseVal.Result.getCreditCardValidationResponse.issuingNetwork);
            Console.WriteLine("ESTA ES LA RESPUESTA" + responseVal.Status);
            String issuingNetwork = responseVal.Result.getCreditCardValidationResponse.issuingNetwork;

            if (issuingNetwork == "Invalid Card")
            {
                return false;
            }
            else
            {
                return true;
            }
            /*
            if (_setting.Value.MinOrderValue.HasValue && _setting.Value.MinOrderValue.Value > cart.OrderTotal)
            {
                return false;
            }

            if (_setting.Value.MaxOrderValue.HasValue && _setting.Value.MaxOrderValue.Value < cart.OrderTotal)
            {
                return false;
            }
            
            return true;*/
        }

    }
}
