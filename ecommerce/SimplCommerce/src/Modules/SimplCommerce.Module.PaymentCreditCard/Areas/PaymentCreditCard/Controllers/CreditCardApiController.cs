using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentCreditCard.Models;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentCreditCard.Areas.PaymentCreditCard.Controllers
{
    [Authorize(Roles = "admin")]
    [Area("PaymentCreditCard")]
    [Route("api/creditcard")]
    public class CoDApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public CoDApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var codProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.CreditCardProviderId);
            if (string.IsNullOrEmpty(codProvider.AdditionalSettings))
            {
                return Ok(new CreditCardSetting());
            }

            var model = JsonConvert.DeserializeObject<CreditCardSetting>(codProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] CreditCardSetting model)
        {
            if (ModelState.IsValid)
            {
                var codProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.CreditCardProviderId);
                codProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}
