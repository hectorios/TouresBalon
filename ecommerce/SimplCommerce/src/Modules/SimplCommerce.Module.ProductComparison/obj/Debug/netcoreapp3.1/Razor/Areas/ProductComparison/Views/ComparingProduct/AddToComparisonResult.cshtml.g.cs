#pragma checksum "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82fc18810a87570c324a7047512fe18ddb57d4d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ProductComparison_Views_ComparingProduct_AddToComparisonResult), @"mvc.1.0.view", @"/Areas/ProductComparison/Views/ComparingProduct/AddToComparisonResult.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82fc18810a87570c324a7047512fe18ddb57d4d6", @"/Areas/ProductComparison/Views/ComparingProduct/AddToComparisonResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"252a5853f5646565b6d19f2f67b215e8a2ab4af3", @"/Areas/ProductComparison/Views/_ViewImports.cshtml")]
    public class Areas_ProductComparison_Views_ComparingProduct_AddToComparisonResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SimplCommerce.Module.ProductComparison.Areas.ProductComparison.ViewModels.AddToComparisonResult>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/compare-products"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"modal-header\">\r\n    <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n    <h4 class=\"modal-title\" id=\"myModalLabel\">");
#nullable restore
#line 5 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
                                         Write(Localizer[Model.Message]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n</div>\r\n<div class=\"modal-body\">\r\n");
#nullable restore
#line 8 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
     foreach (var product in Model.ProductComparisons)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-md-3\">\r\n                <img");
            BeginWriteAttribute("alt", " alt=\"", 522, "\"", 548, 1);
#nullable restore
#line 12 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
WriteAttributeValue("", 528, product.ProductName, 528, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 567, "\"", 594, 1);
#nullable restore
#line 12 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
WriteAttributeValue("", 573, product.ProductImage, 573, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n            <div class=\"col-md-7\">\r\n                <h4>");
#nullable restore
#line 15 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
               Write(product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                <p>");
#nullable restore
#line 16 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
              Write(product.CalculatedProductPrice.PriceString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"col-md-2 product-comparison-result-remove\">\r\n                <a href=\"#\" class=\"remove-item-comparison\" data-product-id=\"");
#nullable restore
#line 19 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
                                                                       Write(product.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 19 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
                                                                                           Write(Localizer["Remove"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 22 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
    }    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">");
#nullable restore
#line 25 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
                                                                  Write(Localizer["Continue shopping"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82fc18810a87570c324a7047512fe18ddb57d4d69536", async() => {
#nullable restore
#line 26 "C:\Users\Usuario\PICA\TouresBalon\ecommerce\SimplCommerce\src\Modules\SimplCommerce.Module.ProductComparison\Areas\ProductComparison\Views\ComparingProduct\AddToComparisonResult.cshtml"
                                                                  Write(Localizer["Compare"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SimplCommerce.Module.ProductComparison.Areas.ProductComparison.ViewModels.AddToComparisonResult> Html { get; private set; }
    }
}
#pragma warning restore 1591
