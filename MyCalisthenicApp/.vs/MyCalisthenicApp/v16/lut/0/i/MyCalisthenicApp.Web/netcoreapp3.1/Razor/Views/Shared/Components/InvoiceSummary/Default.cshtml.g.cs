#pragma checksum "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "588870f817dafc5dbc8089f91f4d384822ad1310"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_InvoiceSummary_Default), @"mvc.1.0.view", @"/Views/Shared/Components/InvoiceSummary/Default.cshtml")]
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
#nullable restore
#line 2 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"588870f817dafc5dbc8089f91f4d384822ad1310", @"/Views/Shared/Components/InvoiceSummary/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"528ff86fbad13798d15e283cfce9fdfcdf7327e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_InvoiceSummary_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<ProductsShoppingBagViewModel>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
  
    var user = await UserManager.GetUserAsync(User);

#line default
#line hidden
#nullable disable
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "588870f817dafc5dbc8089f91f4d384822ad13108108", async() => {
                WriteLiteral("\r\n    <div id=\"div1\" class=\"col-lg-5\">\r\n        <div id=\"invoice\" class=\"invoice\">\r\n            <div class=\"invoice-top\">\r\n                <h2>Invoice # ");
#nullable restore
#line 13 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                         Write(user.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(" Summary</h2>\r\n                <h6>Estimated Delivery : ");
#nullable restore
#line 14 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                                     Write(DateTime.UtcNow.AddDays(2).ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                <p>");
#nullable restore
#line 15 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
               Write(user.FirstName + " " + user.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <p>");
#nullable restore
#line 16 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
              Write(user.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"invoice-bottom\">\r\n");
#nullable restore
#line 19 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                  
                    decimal? membershipPrice = user.Orders.Where(o => o.MembershipPrice != null).Select(o => o.MembershipPrice).FirstOrDefault();
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                 if (membershipPrice != null && user.HasMembership == false)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"text-danger\">\r\n                        Membership\r\n                        <span class=\"float-right text-right text-danger\">$");
#nullable restore
#line 26 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                                                                     Write(membershipPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    </p>\r\n                    <br />\r\n");
#nullable restore
#line 29 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                <ul class=\"single-item\">\r\n\r\n");
#nullable restore
#line 32 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                     foreach (var product in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"single-cart-item\">\r\n                            <div class=\"thumb\">\r\n                                <img id=\"image\"");
                BeginWriteAttribute("src", " src=\"", 1506, "\"", 1529, 1);
#nullable restore
#line 36 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
WriteAttributeValue("", 1512, product.ImageUrl, 1512, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1530, "\"", 1536, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"content\">\r\n                                <h3>");
#nullable restore
#line 39 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                               Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("<br> <span>");
#nullable restore
#line 39 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                                                       Write(product.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></h3>\r\n                                <span>$");
#nullable restore
#line 40 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                                  Write(product.Price.ToString("0.00"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                            </div>\r\n\r\n                        </li>\r\n");
#nullable restore
#line 44 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </ul>\r\n");
#nullable restore
#line 47 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                  
                    decimal? deliveryPrice = user.Orders.Where(o => o.DeliveryPrice != null).Select(o => o.DeliveryPrice).FirstOrDefault();
                    var order = user.Orders.Where(o => o.UserId == user.Id).FirstOrDefault();
                

#line default
#line hidden
#nullable disable
                WriteLiteral("                <br />\r\n");
#nullable restore
#line 52 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                 if (deliveryPrice != null && order.Status != OrderStatus.Sent)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"text-dark\">\r\n                        Delivery Price\r\n                        <span class=\"float-right text-right text-dark\">$");
#nullable restore
#line 56 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                                                                   Write(deliveryPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    </p>\r\n");
#nullable restore
#line 58 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"total\">\r\n\r\n                    <h3>Total</h3>\r\n");
#nullable restore
#line 62 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                      
                        decimal totalPrice = 0;
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                     foreach (var product in Model)
                    {
                        totalPrice += product.Price;
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                      
                        decimal? absolutePrice = 0;
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 73 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                     if (user.HasMembership == false && membershipPrice != null && deliveryPrice != null && order.Status != OrderStatus.Sent)
                    {
                        absolutePrice = membershipPrice + totalPrice + deliveryPrice;

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 79 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                     if (deliveryPrice == null && user.HasMembership == false && membershipPrice != null)
                    {
                        absolutePrice = membershipPrice + totalPrice;

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                     if (deliveryPrice != null && order.Status != OrderStatus.Sent && (user.HasMembership == true || membershipPrice == null))
                    {
                        absolutePrice = totalPrice + deliveryPrice;

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                     if (deliveryPrice == null && (user.HasMembership == true || membershipPrice == null))
                    {
                        absolutePrice = totalPrice;

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"text-right\">$");
#nullable restore
#line 94 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\InvoiceSummary\Default.cshtml"
                                      Write(string.Format("{0:N}", absolutePrice));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                </div>
                <div id=""cancelBtn"" class=""btn-wrapper desktop-center"">
                    <button onclick=""javascript: hideDiv(); showBtn()"" class=""btn btn-danger"">Cancel <i class=""fa fa-long-arrow-right""></i></button>
                </div>
                <div id=""printBtn"" class=""btn-wrapper desktop-center mt-3"">
                    <b hidden>Div 1:</b> <a class=""bg-primary pl-3 pr-3 pt-1 pb-1"" href=""javascript:printDiv('div1')"">Print</a>
                </div>
            </div>
        </div>
        <button id=""get"" onclick=""javascript: showDiv();hideBtn()"" class=""btn btn-success"">Get Invoice <i class=""fa fa-long-arrow-right""></i></button>
    </div>
    <iframe name=""print_frame"" width=""0"" height=""0"" frameborder=""0"" src=""about:blank""></iframe>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>

<script language=javascript type='text/javascript'>
    function hideDiv() {
        if (document.getElementById) {
            document.getElementById('invoice').style.visibility = 'hidden';
        }
    }
    function showDiv() {
        if (document.getElementById) {
            document.getElementById('invoice').style.visibility = 'visible';
        }
    }
    function showBtn() {
        if (document.getElementById) {
            document.getElementById('get').style.visibility = 'visible';
        }
    }
    function hideBtn() {
        if (document.getElementById) {
            document.getElementById('get').style.visibility = 'hidden';
        }
    }
    window.onload = function () {
        document.getElementById('get').style.visibility = 'hidden';
    };
    window.onload = function () {
        document.getElementById('invoice').style.visibility = 'hidden';
    };
</script>
<script>
    printDivCSS = new String('<link href=""myprintstyle.css"" rel=""styles");
            WriteLiteral(@"heet"" type=""text/css"">')
    function printDiv(divId) {

        var cancelButton = document.getElementById(""cancelBtn"");
        var printButton = document.getElementById(""printBtn"");

        printButton.style.visibility = 'hidden';
        cancelButton.style.visibility = 'hidden';

        window.frames[""print_frame""].document.body.innerHTML = printDivCSS + document.getElementById(divId).innerHTML;
        window.frames[""print_frame""].window.focus();
        window.frames[""print_frame""].window.print();

        printButton.style.visibility = 'visible';
        cancelButton.style.visibility = 'visible';
    }
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<ProductsShoppingBagViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591