#pragma checksum "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Payments\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ee7cbb86287d015a5f0cae781f57b369e927381"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payments_Index), @"mvc.1.0.view", @"/Views/Payments/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ee7cbb86287d015a5f0cae781f57b369e927381", @"/Views/Payments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"528ff86fbad13798d15e283cfce9fdfcdf7327e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Payments_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderCheckoutViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Payments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "OnDelivery", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Payments\Index.cshtml"
  
    ViewData["Title"] = "Checkout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ee7cbb86287d015a5f0cae781f57b369e9273819675", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title> ");
#nullable restore
#line 11 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Payments\Index.cshtml"
       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <!-- favicon -->
    <link rel=icon href=/assets/img/favicon.png sizes=""20x20"" type=""image/png"">
    <!-- animate -->
    <link rel=""stylesheet"" href=""/assets/css/animate.css"">
    <!-- bootstrap -->
    <link rel=""stylesheet"" href=""/assets/css/bootstrap.min.css"">
    <!-- magnific popup -->
    <link rel=""stylesheet"" href=""/assets/css/magnific-popup.css"">
    <!-- Slick -->
    <link rel=""stylesheet"" href=""/assets/css/slick.css"" />
    <link rel=""stylesheet"" href=""/assets/css/slick-theme.css"" />
    <!-- nice select -->
    <link rel=""stylesheet"" href=""/assets/css/nice-select.css"">
    <!-- owl carousel -->
    <link rel=""stylesheet"" href=""/assets/css/owl.carousel.min.css"">
    <!-- fontawesome -->
    <link rel=""stylesheet"" href=""/assets/css/font-awesome.min.css"">
    <!-- flaticon -->
    <link rel=""stylesheet"" href=""/assets/css/flaticon.css"">
    <!-- hamburgers -->
    <link rel=""stylesheet"" href=""/assets/css/hamburgers.min.css"">
    <!-- Main Stylesheet -->
    <link ");
                WriteLiteral("rel=\"stylesheet\" href=\"/assets/css/style.css\">\r\n    <!-- responsive Stylesheet -->\r\n    <link rel=\"stylesheet\" href=\"/assets/css/responsive.css\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ee7cbb86287d015a5f0cae781f57b369e92738112415", async() => {
                WriteLiteral(@"

    <!-- breadcrumb area -->
    <div class=""breadcrumb-style-1 shopping-cart-breadcrumb-overlay"" style=""background-image:url(/assets/img/bg/shopping-cart.png);"">
        <div class=""breadcrumb-inner"">
            <h1 class=""page-title"">Payment Method</h1>
            <ul class=""page-list margin-bottom-7"">
                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ee7cbb86287d015a5f0cae781f57b369e92738113018", async() => {
                    WriteLiteral("Home");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ee7cbb86287d015a5f0cae781f57b369e92738114475", async() => {
                    WriteLiteral("Payment method");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"</li>
            </ul>
        </div>
    </div>
    <!-- breadcrumb area end -->
    <!-- payment start -->

    <div class=""payment-area"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-7"">
                    <div class=""payment-content"">
                        <div class=""title"">
                            <h2>Payment Method</h2>
                        </div>
                        <div class=""payment-tab"">
                            <ul class=""nav nav-pills"">
                                <li>
                                    <a data-toggle=""pill"" href=""#home"" class=""active"">
                                        <div class=""tab-item"">
                                            <h1>On delivery</h1>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a data-toggle=""pill"" h");
                WriteLiteral(@"ref=""#menu1"">
                                        <div class=""tab-item"">
                                            <h1>EPay</h1>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a data-toggle=""pill"" href=""#menu2"">
                                        <div class=""tab-item"">
                                            <h1>PayPal</h1>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                            <div class=""tab-content"">
                                <div id=""home"" class=""tab-pane fade in active show"">
                                    <div class=""all-tab-content"">
                                        <h2>Payment Details</h2>
                                        <div class=""card-option"">
               ");
                WriteLiteral("                             <div class=\"form-group\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ee7cbb86287d015a5f0cae781f57b369e92738118186", async() => {
                    WriteLiteral(@"
                                                    <img src=""https://www.shop.sws-solutions.nl/content/images/thumbs/0001187_cash-on-delivery-with-verification-plugin-for-nopcommerce_300.jpeg"" height=""180"" width=""350"" alt=""epay-logo"" />
                                                    <div class=""form-row"">
                                                        <div class=""form-group col-md-9 offset-md-1"">
                                                            <div class=""btn-wrapper"">
                                                                <button type=""submit"" class=""btn btn-block btn-element btn-lg-size btn-main-color btn-rounded"">Checkout</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Payments\Index.cshtml"
                                                                                                          WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id=""menu1"" class=""tab-pane fade"">
                                    <div class=""all-tab-content"">
                                        <h2>Coming soon...</h2>
                                        <div class=""card-option"">
                                            <div class=""form-group"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ee7cbb86287d015a5f0cae781f57b369e92738122531", async() => {
                    WriteLiteral(@"
                                                    <div class=""form-row"">
                                                        <div class=""form-group col-md-7"">
                                                            <label for=""email"">Enter email</label>
                                                            <input type=""email"" class=""form-control"" id=""email"" placeholder=""demo@gmail.com"">
                                                        </div>
                                                        <div class=""form-group col-md-5 d-none d-md-block"">
                                                            <img src=""https://www.oltrans.bg/wp-content/uploads/2017/01/epay2.jpg"" height=""100"" width=""300"" alt=""easypay-logo"" />
                                                        </div>
                                                    </div>
                                                    <div class=""form-row"">
                                                        <div");
                    WriteLiteral(" class=\"form-group col-md-9 offset-md-1\">\r\n                                                        </div>\r\n                                                    </div>\r\n                                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id=""menu2"" class=""tab-pane fade"">
                                    <div class=""all-tab-content"">
                                        <h2>Coming soon...</h2>
                                        <div class=""card-option"">
                                            <div class=""form-group"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ee7cbb86287d015a5f0cae781f57b369e92738125718", async() => {
                    WriteLiteral(@"
                                                    <div class=""form-row"">
                                                        <div class=""form-group col-md-7"">
                                                            <label for=""email"">Enter email</label>
                                                            <input type=""email"" class=""form-control"" id=""email"" placeholder=""demo@gmail.com"">
                                                        </div>
                                                        <div class=""form-group col-md-5 d-none d-md-block"">
                                                            <img src=""https://mm.ge/uploaded/newslwMe3dxL.png"" height=""100"" width=""300"" alt=""easypay-logo"" />
                                                        </div>
                                                    </div>
                                                    <div class=""form-row"">
                                                        <div class=""form-group c");
                    WriteLiteral("ol-md-9 offset-md-1\">\r\n                                                        </div>\r\n                                                    </div>\r\n                                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                ");
#nullable restore
#line 158 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Payments\Index.cshtml"
           Write(await Component.InvokeAsync("InvoiceSummary"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

            </div>
        </div>
    </div>
    <!-- payment end -->
    <!-- jquery -->
    <script src=""/assets/js/jquery-2.2.4.min.js""></script>
    <!-- popper -->
    <script src=""/assets/js/popper.min.js""></script>
    <!-- bootstrap -->
    <script src=""/assets/js/bootstrap.min.js""></script>
    <!-- magnific popup -->
    <script src=""/assets/js/jquery.magnific-popup.js""></script>
    <!-- wow -->
    <script src=""/assets/js/wow.min.js""></script>
    <!-- nice select -->
    <script src=""/assets/js/nice-select.js""></script>
    <!-- counter up -->
    <script src=""/assets/js/counter-up.js""></script>
    <!-- owl carousel -->
    <script src=""/assets/js/owl.carousel.min.js""></script>
    <!-- Slick -->
    <script src=""/assets/js/slick.min.js""></script>
    <!-- Slick Animation -->
    <script src=""/assets/js/slick-animation.js""></script>
    <!-- waypoint -->
    <script src=""/assets/js/waypoints.min.js""></script>
    <!-- counterup -->
    <script src=""/assets/js/jquer");
                WriteLiteral(@"y.counterup.min.js""></script>
    <!-- imageloaded -->
    <script src=""/assets/js/imagesloaded.pkgd.min.js""></script>
    <!-- isotope -->
    <script src=""/assets/js/isotope.pkgd.min.js""></script>
    <!-- rProgressbar -->
    <script src=""/assets/js/jQuery.rProgressbar.min.js""></script>
    <!-- main js -->
    <script src=""/assets/js/main.js""></script>
    <script src=""/assets/js/script.js""></script>
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
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderCheckoutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
