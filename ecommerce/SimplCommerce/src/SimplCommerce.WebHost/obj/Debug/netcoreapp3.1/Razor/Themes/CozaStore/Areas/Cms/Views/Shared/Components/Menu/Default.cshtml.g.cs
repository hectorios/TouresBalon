#pragma checksum "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1712066baaac8b827e7bb753c56367b92491143f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Themes_CozaStore_Areas_Cms_Views_Shared_Components_Menu_Default), @"mvc.1.0.view", @"/Themes/CozaStore/Areas/Cms/Views/Shared/Components/Menu/Default.cshtml")]
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
#line 1 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\_ViewImports.cshtml"
using SimplCommerce.Module.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1712066baaac8b827e7bb753c56367b92491143f", @"/Themes/CozaStore/Areas/Cms/Views/Shared/Components/Menu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0711de80d1ef38a151e852f8bb051bee04f5f260", @"/Themes/CozaStore/Areas/Cms/Views/_ViewImports.cshtml")]
    public class Themes_CozaStore_Areas_Cms_Views_Shared_Components_Menu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SimplCommerce.Module.Cms.Areas.Cms.ViewModels.MenuItemVm>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul>\r\n");
#nullable restore
#line 4 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"p-b-10\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 162, "\"", 179, 1);
#nullable restore
#line 7 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 169, item.Link, 169, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"stext-107 cl7 hov-cl1 trans-04\">\r\n            ");
#nullable restore
#line 8 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </a>\r\n");
#nullable restore
#line 10 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
         if (item.ChildItems.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <ul>\r\n");
#nullable restore
#line 13 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
                 foreach (var childItem in item.ChildItems)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 432, "\"", 454, 1);
#nullable restore
#line 15 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
WriteAttributeValue("", 439, childItem.Link, 439, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
                                             Write(childItem.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 16 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n");
#nullable restore
#line 18 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </li>\r\n");
#nullable restore
#line 20 "C:\Users\hecto\source\repos\SimplCommerce\src\SimplCommerce.WebHost\Themes\CozaStore\Areas\Cms\Views\Shared\Components\Menu\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SimplCommerce.Module.Cms.Areas.Cms.ViewModels.MenuItemVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
