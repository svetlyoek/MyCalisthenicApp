#pragma checksum "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Partials\_BrandAreaPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d827e4c9d34f37ef9a560ac25392f3e863d48bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Partials__BrandAreaPartial), @"mvc.1.0.view", @"/Views/Shared/Partials/_BrandAreaPartial.cshtml")]
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
#line 1 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Services.MessageSender;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Memberships;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Categories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Programs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Contacts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Posts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Comments;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Products;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Subscribes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Addresses;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Coupons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Orders;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.OrderProducts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.ViewModels.Suppliers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Models.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Models.ShopEntities.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Models.BlogEntities.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d827e4c9d34f37ef9a560ac25392f3e863d48bb", @"/Views/Shared/Partials/_BrandAreaPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"528ff86fbad13798d15e283cfce9fdfcdf7327e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Partials__BrandAreaPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- brand-area start -->
<div class=""brand-area margin-top-80"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""brand-slider"">
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand1.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand2.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand3.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand4.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand5.jpg"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
              ");
            WriteLiteral(@"          <img src=""/assets/img/brand/brand1.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand2.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand3.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand4.png"" alt=""brand"">
                    </div>
                    <div class=""brant-item"">
                        <img src=""/assets/img/brand/brand5.jpg"" alt=""brand"">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- brand-area end -->
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591