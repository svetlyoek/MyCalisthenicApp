#pragma checksum "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Shared\Components\HomeLatestNews\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "505df39aa3f44cbcad372224cdce535dbb9eab35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_HomeLatestNews_Default), @"mvc.1.0.view", @"/Views/Shared/Components/HomeLatestNews/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"505df39aa3f44cbcad372224cdce535dbb9eab35", @"/Views/Shared/Components/HomeLatestNews/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130a4f893102487b0e9f119fdba2626b7b2c29c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_HomeLatestNews_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blogs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" <!-- news-area start -->\r\n");
            WriteLiteral(@"
<div class=""news-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""section-title title-padding text-center"">
                    <p class=""subtitle"">Calisthenic News For You</p>
                    <h1 class=""title"">Latest News</h1>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-12 col-sm-12 col-11 news-slider text-center"">
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/1.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab355463", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">20 Dec</span><br>
                        <span>2019</span>
                    </div>
                </div>
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/2.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab357792", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">25 Dec</span><br>
                        <span>2019</span>
                    </div>
                </div>
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/3.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab3510121", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">24 Jun</span><br>
                        <span>2019</span>
                    </div>
                </div>
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/4.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab3512451", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">14 Jan</span><br>
                        <span>2019</span>
                    </div>
                </div>
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/5.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab3514781", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">10 Jan</span><br>
                        <span>2019</span>
                    </div>
                </div>
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/6.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab3517111", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">09 Aug</span><br>
                        <span>2019</span>
                    </div>
                </div>
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/7.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab3519441", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">03 May</span><br>
                        <span>2019</span>
                    </div>
                </div>
                <div class=""news-item-style-01"">
                    <div class=""thumb"">
                        <img src=""assets/img/home/news/8.png"" alt=""news"">
                    </div>
                    <div class=""content"">
                        <div class=""blog-meta"">
                            <h6 class=""d-flex justify-content-between""><i class=""fa fa-user-o"" aria-hidden=""true""></i> By Rasel<i class=""fa fa-comment-o"" aria-hidden=""true""></i> 9 comments</h6>
                        </div>
                        <h3>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "505df39aa3f44cbcad372224cdce535dbb9eab3521771", async() => {
                WriteLiteral("World Wide Ocassion");
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
            WriteLiteral(@"</h3>
                        <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                    </div>
                    <div class=""hover-content"">
                        <span class=""border-bottom"">12 Jul</span><br>
                        <span>2019</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- news-area end -->");
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
