#pragma checksum "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Home\ShoppingBag.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a311813bce9fce93519fec5c1aa54737999740e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShoppingBag), @"mvc.1.0.view", @"/Views/Home/ShoppingBag.cshtml")]
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
using MyCalisthenicApp.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Web.ViewModels.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\_ViewImports.cshtml"
using MyCalisthenicApp.Web.ViewModels.Blogs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a311813bce9fce93519fec5c1aa54737999740e2", @"/Views/Home/ShoppingBag.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c3028c37dddf333e64d18bc4bb6ea3d4c2f2e47", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShoppingBag : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Home\ShoppingBag.cshtml"
   
    ViewData["Title"] = "Shopping Bag";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a311813bce9fce93519fec5c1aa54737999740e24766", async() => {
                WriteLiteral("\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\">\r\n    <title> ");
#nullable restore
#line 11 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Home\ShoppingBag.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a311813bce9fce93519fec5c1aa54737999740e27508", async() => {
                WriteLiteral(@"

    <!-- breadcrumb area -->
    <div class=""breadcrumb-style-1 cart-breadcrumb-overlay"" style=""background-image:url(/assets/img/bg/shopping-bag.png);"">
        <div class=""breadcrumb-inner"">
            <h1 class=""page-title"">Shopping Bag</h1>
            <ul class=""page-list margin-bottom-0 margin-top-10"">
                <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a311813bce9fce93519fec5c1aa54737999740e28112", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a311813bce9fce93519fec5c1aa54737999740e29568", async() => {
                    WriteLiteral("Shopping Bag");
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
                WriteLiteral("</li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    <!-- breadcrumb area end -->\r\n    <!-- cart content start -->\r\n\r\n");
                WriteLiteral(@"
    <section class=""cart-content-area"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""cart-title"">
                        <h2>Product List</h2>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-8"">
                    <div class=""single-cart-list"">
                        <table class=""table table-borderless"">
                            <tbody>
                                <tr>
                                    <td><a href=""#"">X</a></td>
                                    <td><img src=""/assets/img/product-details/single-cart.png""");
                BeginWriteAttribute("alt", " alt=\"", 2927, "\"", 2933, 0);
                EndWriteAttribute();
                WriteLiteral(@"></td>
                                    <td><p class=""font-semibold"">Dumbbell variations machine</p></td>
                                    <td><p>$120.00</p></td>
                                    <td><p>Quantity</p></td>
                                    <td>
                                        <div class=""input-group mb-2"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""minus-btn""><i class=""fa fa-minus""></i></a>
                                            </div>
                                            <input type=""number"" id=""qty_input"" class=""form-control form-control-sm"" value=""1"" min=""1"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""plus-btn""><i class=""fa fa-plus""></i></a>
                                            </div>
                                        </d");
                WriteLiteral(@"iv>
                                    </td>
                                </tr>
                                <tr>
                                    <td><a href=""#"">X</a></td>
                                    <td><img src=""/assets/img/product-details/cart2.png""");
                BeginWriteAttribute("alt", " alt=\"", 4235, "\"", 4241, 0);
                EndWriteAttribute();
                WriteLiteral(@"></td>
                                    <td><p class=""font-semibold"">The chest press machine</p></td>
                                    <td><p>$820.00</p></td>
                                    <td><p>Quantity</p></td>
                                    <td>
                                        <div class=""input-group mb-2"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""minus-btn2""><i class=""fa fa-minus""></i></a>
                                            </div>
                                            <input type=""number"" id=""qty_input2"" class=""form-control form-control-sm"" value=""1"" min=""1"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""plus-btn2""><i class=""fa fa-plus""></i></a>
                                            </div>
                                        </di");
                WriteLiteral(@"v>
                                    </td>
                                </tr>
                                <tr>
                                    <td><a href=""#"">X</a></td>
                                    <td><img src=""/assets/img/product-details/cart3.png""");
                BeginWriteAttribute("alt", " alt=\"", 5542, "\"", 5548, 0);
                EndWriteAttribute();
                WriteLiteral(@"></td>
                                    <td><p class=""font-semibold"">Shoulder press machine</p></td>
                                    <td><p>$620.00</p></td>
                                    <td><p>Quantity</p></td>
                                    <td>
                                        <div class=""input-group mb-2"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""minus-btn3""><i class=""fa fa-minus""></i></a>
                                            </div>
                                            <input type=""number"" id=""qty_input3"" class=""form-control form-control-sm"" value=""1"" min=""1"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""plus-btn3""><i class=""fa fa-plus""></i></a>
                                            </div>
                                        </div");
                WriteLiteral(@">
                                    </td>
                                </tr>
                                <tr>
                                    <td><a href=""#"">X</a></td>
                                    <td><img src=""/assets/img/product-details/cart4.png""");
                BeginWriteAttribute("alt", " alt=\"", 6848, "\"", 6854, 0);
                EndWriteAttribute();
                WriteLiteral(@"></td>
                                    <td><p class=""font-semibold"">The leg extension machine</p></td>
                                    <td><p>$570.00</p></td>
                                    <td><p>Quantity</p></td>
                                    <td>
                                        <div class=""input-group mb-2"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""minus-btn4""><i class=""fa fa-minus""></i></a>
                                            </div>
                                            <input type=""number"" id=""qty_input4"" class=""form-control form-control-sm"" value=""1"" min=""1"">
                                            <div class=""input-group-prepend"">
                                                <a class=""btn btn-sm"" id=""plus-btn4""><i class=""fa fa-plus""></i></a>
                                            </div>
                                        </");
                WriteLiteral(@"div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class=""coupon-title"">
                            <h2>Have a coupon?</h2>
                        </div>
                        <div class=""apply-coupon-form"">
                            <div class=""input-group margin-top-30"">
                                <input type=""text"" class=""form-control"" placeholder=""Coupon Code"">
                                <span class=""input-group-btn"">
                                    <button class=""btn btn-default submit-btn"" type=""button"">Apply Coupon</button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""cart-total-list"">
                        <div class=""total-title"">
                  ");
                WriteLiteral(@"          <h2>Cart totals</h2>
                        </div>
                        <div class=""cart-price"">
                            <p>Sub Total <span class=""float-right text-right"">$250.00</span></p>
                            <p>Shipping Charge <span class=""float-right text-right"">$25.00</span></p>
                        </div>
                        <div class=""cart-price-total"">
                            <p>Total Price <span class=""float-right text-right"">$275.00</span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- cart content end -->

");
                WriteLiteral("\r\n    <!-- delivery-area start -->\r\n    <div class=\"delivery-area padding-top-100\">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                \r\n                ");
#nullable restore
#line 182 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Home\ShoppingBag.cshtml"
           Write(await  Component.InvokeAsync("DeliveryOptions"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                \r\n                ");
#nullable restore
#line 184 "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Home\ShoppingBag.cshtml"
           Write(await  Component.InvokeAsync("InvoiceSummary"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

            </div>
        </div>
    </div>
    <!-- delivery-area end -->

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
    <script src=""/assets/");
                WriteLiteral(@"js/jquery.counterup.min.js""></script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
