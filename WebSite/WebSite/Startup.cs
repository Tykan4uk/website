using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSite.Configurations;
using WebSite.Services;
using WebSite.Services.Abstractions;

namespace WebSite
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .AddEnvironmentVariables();

            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddControllersWithViews();
            services.AddTransient<IHttpClientService, HttpClientService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IRelatedProductService, RelatedProductService>();
            services.AddTransient<ICartService, CartService>();
            services.Configure<Config>(AppConfiguration);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "cookie";
                options.DefaultSignInScheme = "cookie";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("cookie")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false; // dev only

                options.ClientId = "pkce_client";
                options.ClientSecret = "acf2ec6fb01a4b698ba240c2b10a0243";
                options.ResponseType = "code";
                options.ResponseMode = "form_post";
                options.CallbackPath = "/signin-oidc";

                // Enable PKCE (authorization code flow only)
                options.UsePkce = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Strict });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
