#pragma checksum "E:\Soft Uni\CODES\MyCalisthenicApp\MyCalisthenicApp\MyCalisthenicApp.Web\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41474633296ffcc80f7b1d24e3fc0066fc1ab269"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41474633296ffcc80f7b1d24e3fc0066fc1ab269", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31b05da6bebe63efbdbf0cc1765d09bf7b12e39a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41474633296ffcc80f7b1d24e3fc0066fc1ab2693323", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>MyCalisthenicApp</title>
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
    <link rel=""stylesheet"" href=");
                WriteLiteral(@"""/assets/css/font-awesome.min.css"">
    <!-- flaticon -->
    <link rel=""stylesheet"" href=""/assets/css/flaticon.css"">
    <!-- hamburgers -->
    <link rel=""stylesheet"" href=""/assets/css/hamburgers.min.css"">
    <!-- Main Stylesheet -->
    <link rel=""stylesheet"" href=""/assets/css/style.css"">
    <!-- responsive Stylesheet -->
    <link rel=""stylesheet"" href=""/assets/css/responsive.css"">
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41474633296ffcc80f7b1d24e3fc0066fc1ab2695812", async() => {
                WriteLiteral(@"
    <!-- breadcrumb area -->
    <div class=""breadcrumb-style-1 about-breadcrumb-overlay"" style=""background-image:url(/assets/img/bg/about.png);"">
        <div class=""breadcrumb-inner"">
            <h1 class=""page-title"">About us</h1>
            <ul class=""page-list"">
                <li><a href=""/"">Home</a></li>
                <li><a href=""/Home/About"">About Us</a></li>
            </ul>
        </div>
    </div>
    <!-- breadcrumb area end -->
    <!-- about start -->
    <div class=""about-page-top"">
        <div class=""container section-padding"">
            <div class=""row"">
                <div class=""col-lg-6 col-xl-6 d-flex"">
                    <div class=""about-content align-self-center"">
                        <h3 class=""about-title"">About Calisthenic</h3>
                        <p class=""font-regular"">Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis libero. Nulla interdum erat nec tincidunt laoreet. In ac consequat");
                WriteLiteral(@" risus. Donec a lectus mauris. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In maximus volutpat vehicula. Morbi ut dui iss. Sed eros eros, rutrum eu quam a venenatis.</p> <p>Ut pulvinar mi ac sem sagittis, ut consectetur ipsum porta. Nullam vitae tellus id ante fermentum aliquam quis at metus. Curabitur nec tincidunt purus, sed faucibus dolor. Aliquam erat volutpat.</p>
                        <ul>
                            <li><i class=""fa fa-check""></i> Pellentesque pellentesque odio et porta accumsan.</li>
                            <li><i class=""fa fa-check""></i> Proin et augue et justo accumsan condimentum.</li>
                            <li><i class=""fa fa-check""></i> Donec viverra urna id congue fringilla.</li>
                        </ul>
                    </div>
                </div>
                <div class=""col-lg-6 col-xl-6"">
                    <div class=""about-left"">
                        <div class=""thumb"">
                    ");
                WriteLiteral(@"        <img src=""/assets/img/bg/about-right.png"" alt=""About"">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- about end -->
    <!-- project-counter start -->
    <div class=""project-counter"">
        <div class=""container"">
            <div class=""row justify-content-center"">
                <div class=""col-12"">
                    <div class=""project-counter__boxes"">
                        <div class=""row justify-content-center"">
                            <div class=""col"">
                                <div class=""project-counter__box"">
                                    <div class=""project-counter__box-content"">
                                        <div class=""icon"">
                                            <img src=""/assets/img/counterup/1.png"" alt=""counter img"">
                                        </div>
                                        <span class=""project-counter__is"">1250");
                WriteLiteral(@"</span>
                                        <span class=""project-counter__text"">all equipments</span>
                                    </div>
                                </div>
                            </div>
                            <div class=""col"">
                                <div class=""project-counter__box"">
                                    <div class=""project-counter__box-content"">
                                        <div class=""icon"">
                                            <img src=""/assets/img/counterup/2.png"" alt=""counter img"">
                                        </div>
                                        <span class=""project-counter__is"">200</span>
                                        <span class=""project-counter__text"">Trainers</span>
                                    </div>
                                </div>
                            </div>
                            <div class=""col"">
                                <div class=""");
                WriteLiteral(@"project-counter__box"">
                                    <div class=""project-counter__box-content"">
                                        <div class=""icon"">
                                            <img src=""/assets/img/counterup/3.png"" alt=""counter img"">
                                        </div>
                                        <span class=""project-counter__is"">2500</span>
                                        <span class=""project-counter__text"">All Trainee</span>
                                    </div>
                                </div>
                            </div>
                            <div class=""col"">
                                <div class=""project-counter__box"">
                                    <div class=""project-counter__box-content"">
                                        <div class=""icon"">
                                            <img src=""/assets/img/counterup/4.png"" alt=""counter img"">
                                        </div>
");
                WriteLiteral(@"                                        <span class=""project-counter__is"">8</span>
                                        <span class=""project-counter__text"">World Challange</span>
                                    </div>
                                </div>
                            </div>
                            <div class=""col"">
                                <div class=""project-counter__box"">
                                    <div class=""project-counter__box-content"">
                                        <div class=""icon"">
                                            <img src=""/assets/img/counterup/5.png"" alt=""counter img"">
                                        </div>
                                        <span class=""project-counter__is"">12</span>
                                        <span class=""project-counter__text"">Our Branch</span>
                                    </div>
                                </div>
                            </div>
              ");
                WriteLiteral(@"          </div>
                    </div>
                </div>
            </div>
        </div>
        <!--container-->
    </div>
    <!--project-counter-->
    <!-- home trainer start -->
    <div class=""trainer-area bg-none"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""section-title title-padding-bottom text-center"">
                        <p class=""subtitle"">Your best partner</p>
                        <h1 class=""title"">Meet our expert</h1>
                    </div>
                </div>
            </div>
            <div class=""row class-slider"">
                <div class=""col-md-6"">
                    <div class=""row border-custom"">
                        <div class=""col-md-5"">
                            <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/1.png"" alt=""trainer"">
                            </div>
                        </div");
                WriteLiteral(@">
                        <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Dorothy D. Nabors</h3>
                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <ul class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-text"">
                                            <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
 ");
                WriteLiteral(@"                                       </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
                                            <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class=""row border-custom"">
                        <div class=""col-md-5"">
                         ");
                WriteLiteral(@"   <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/3.png"" alt=""trainer"">
                            </div>
                        </div>
                        <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Surunjit kumar</h3>
                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <ul class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-text"">
                                            <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
            ");
                WriteLiteral(@"                            <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
                                            <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
          ");
                WriteLiteral(@"              </div>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""row border-custom"">
                        <div class=""col-md-5"">
                            <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/2.png"" alt=""trainer"">
                            </div>
                        </div>
                        <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Mushfiqur Rahman</h3>
                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <ul class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-te");
                WriteLiteral(@"xt"">
                                            <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
       ");
                WriteLiteral(@"                                     <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class=""row border-custom"">
                        <div class=""col-md-5"">
                            <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/4.png"" alt=""trainer"">
                            </div>
                        </div>
                        <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Janice Mcreaken</h3>
                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <u");
                WriteLiteral(@"l class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-text"">
                                            <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
            ");
                WriteLiteral(@"                        <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
                                            <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""row border-custom"">
                        <div class=""col-md-5"">
                            <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/2.png"" alt=""trainer"">
                            </div>
                        </div>
                        <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Sharifur Rahman</h3>
");
                WriteLiteral(@"                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <ul class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-text"">
                                            <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        ");
                WriteLiteral(@"<a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
                                            <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class=""row border-custom"">
                        <div class=""col-md-5"">
                            <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/4.png"" alt=""trainer"">
                            </div>
                        </div>
      ");
                WriteLiteral(@"                  <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Naeem Asadee</h3>
                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <ul class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-text"">
                                            <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
               ");
                WriteLiteral(@"                         </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
                                            <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""row border-custom"">
                       ");
                WriteLiteral(@" <div class=""col-md-5"">
                            <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/2.png"" alt=""trainer"">
                            </div>
                        </div>
                        <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Forhad hossain</h3>
                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <ul class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-text"">
                                            <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                      ");
                WriteLiteral(@"              <li class=""icon-list"">
                                        <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
                                            <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </u");
                WriteLiteral(@"l>
                            </div>
                        </div>
                    </div>
                    <div class=""row border-custom"">
                        <div class=""col-md-5"">
                            <div class=""thumb"">
                                <img src=""/assets/img/home/trainer/4.png"" alt=""trainer"">
                            </div>
                        </div>
                        <div class=""col-md-7 d-flex align-items-center"">
                            <div class=""content"">
                                <h3>Md Nasir hossain</h3>
                                <h6>Fitness Trainer</h6>
                                <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis</p>
                                <ul class=""social"">
                                    <li class=""icon-list"">
                                        <a href=""https://twitter.com/officialthenx"" class=""icon-text"">
        ");
                WriteLiteral(@"                                    <i class=""fa fa-twitter""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.facebook.com/OfficialTHENX"" class=""icon-text"">
                                            <i class=""fa fa-facebook-f""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.instagram.com/thenx/"" class=""icon-text"">
                                            <i class=""fa fa-instagram""></i>
                                        </a>
                                    </li>
                                    <li class=""icon-list"">
                                        <a href=""https://www.youtube.com/user/TheMiamiTrainer/videos"" class=""icon-text"">
                     ");
                WriteLiteral(@"                       <i class=""fa fa-youtube""></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- home trainer end -->
    <!-- home explore start -->
    <div class=""explore-area explore-bg margin-top-120"" style=""background-image: url(/assets/img/home/explore2.jpg)"";>
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""explore-title"">

                        <h2>Explore life fitness</h2>
                        <div class=""btn-wrapper"">
                            <a href=""/Home/Membership"" class=""btn btn-element btn-lg btn-main"">Join with us</a>
                        </div>
                    </div>
                </div>
            </div>
        </d");
                WriteLiteral(@"iv>
    </div>
    <!-- home explore end -->
    <!-- mission-area start -->
    <div class=""mission-area"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-4"">
                    <div class=""mission-content"">
                        <h3 class=""serial"">01</h3>
                        <div class=""title"">
                            <h1>Our Mission</h1>
                        </div>
                        <div class=""mission-content"">
                            <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis Nulla interdum erat nec tincidunt laoreet. In</p>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""mission-content"">
                        <h3 class=""serial"">02</h3>
                        <div class=""title"">
                            <h1>Our Vision</h1>
          ");
                WriteLiteral(@"              </div>
                        <div class=""mission-content"">
                            <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis Nulla interdum erat nec tincidunt laoreet. In</p>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4"">
                    <div class=""mission-content"">
                        <h3 class=""serial"">03</h3>
                        <div class=""title"">
                            <h1>Our Value</h1>
                        </div>
                        <div class=""mission-content"">
                            <p>Praesent a diam at velit finibus vehicula sit amet eu dui. Vestibulum rutrum dignissim arcu, vitae convallis Nulla interdum erat nec tincidunt laoreet. In</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <!-- back to top");
                WriteLiteral(@" area start -->
    <div class=""back-to-top"">
        <span class=""back-top""><i class=""fa fa-angle-up""></i></span>
    </div>
    <!-- back to top area end -->
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
    <script src=""/assets/js");
                WriteLiteral(@"/waypoints.min.js""></script>
    <!-- counterup -->
    <script src=""/assets/js/jquery.counterup.min.js""></script>
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
            WriteLiteral("\r\n</html>\r\n");
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
