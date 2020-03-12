namespace MyCalisthenicApp.Web
{
    using System;

    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MyCalisthenicApp.Data;
    using MyCalisthenicApp.Mapping.MappingConfiguration;
    using MyCalisthenicApp.Models;
    using MyCalisthenicApp.Services;
    using MyCalisthenicApp.Services.Contracts;
    using MyCalisthenicApp.Services.MessageSender;
    using MyCalisthenicApp.Web.Common;
    using MyCalisthenicApp.Web.Middlewares;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MyCalisthenicAppDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.Lockout.MaxFailedAccessAttempts = GlobalConstants.MaxFailedAccessAttempts;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<MyCalisthenicAppDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MyCalisthenicAppProfile>();
            });

            // Application services
            services.AddTransient<IUserRequestsService, UserRequestService>();
            services.AddTransient<IProgramsService, ProgramsService>();
            services.AddTransient<IShoppingCartsService, ShoppingCartsService>();
            services.AddTransient<IShoppingBagsService, ShoppingBagsService>();
            services.AddTransient<IExercisesService, ExercisesService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IMembershipsService, MembershipsService>();
            services.AddTransient<IProductsService, ProductsService>();

            services.AddTransient<IEmailSender>(
                serviceProvider => new SendGridEmailSender(this.Configuration["SendGrid:ApiKey"]));

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = this.Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = this.Configuration["Authentication:Facebook:AppSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Home/Error404?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSeedRolesMiddleware();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
