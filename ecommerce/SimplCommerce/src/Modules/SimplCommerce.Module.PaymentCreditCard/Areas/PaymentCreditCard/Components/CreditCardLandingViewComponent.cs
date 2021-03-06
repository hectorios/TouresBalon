﻿using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Web;

namespace SimplCommerce.Module.PaymentCreditCard.Areas.PaymentCreditCard.Components
{
    public class CreditCardLandingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(this.GetViewPath());
        }
    }
}
