using System;
using System.Threading.Tasks;
using BookStore.Application.Abstractions.Test;
using BookStore.Application.Abstractions.User;
using BookStore.Application.Test;
using BookStore.Application.User;
using BookStore.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add Redis cache!
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "127.0.0.1:6379";
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();

            services.AddControllersWithViews(config =>
                    {
                        config.RespectBrowserAcceptHeader = true;
                    })
                    .AddNewtonsoftJson(config =>
                    {
                        // Disable notation ( Name = name )
                        config.SerializerSettings.ContractResolver = null;
                        config.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    })
                    .AddXmlSerializerFormatters();

            services.AddAuthorization();
            services.AddDbContext<DataContext>(ServiceLifetime.Transient);
            services.AddSession();

            services.AddRazorPages()
                    .AddRazorRuntimeCompilation();

            // services.AddHttpClient("test", client =>
            // {
            //     client.BaseAddress = new Uri("http://");
            // });

            //services.AddTransient
            //services.AddScoped
            //services.AddSingleton
            services.AddTransient<ITransientService, TransientService>();
            services.AddScoped<IScopedService, ScopedService>();
            services.AddSingleton<ISingletonService, SingletonService>();
            /* ServiceController -> Index, Index2 */

            services.AddTransient<IUserService, UserService>();
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IConfiguration config)
        {
            // serviceProvider.GetService<T>()
            // var abc = config.GetValue<float>("Test:ABC");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // app.Use(async (req, next) =>
            // {
            //     await Task.Delay(2000);
            //     await next();
            // });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/areas?view=aspnetcore-5.0

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }
}
