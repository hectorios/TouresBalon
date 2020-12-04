using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels
{
    public class ProductsByBrand
    {
        public long BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandSlug { get; set; }

        public int TotalProduct { get; set; }

        public IList<ProductThumbnail> Products { get; set; } = new List<ProductThumbnail>();

        public FilterOption FilterOption { get; set; }

        public SearchOption CurrentSearchOption { get; set; }

        public IList<SelectListItem> AvailableSortOptions => new List<SelectListItem>
        {
            new SelectListItem { Text = "Precio: Menor a Mayor", Value = "price-asc" },
            new SelectListItem { Text = "Precio: Mayor a Menor", Value = "price-desc" }
        };
    }
}
