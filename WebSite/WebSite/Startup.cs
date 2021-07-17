using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<IRelatedProductService, RelatedProductService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IRateLimitService, RateLimitService>();
            services.Configure<Config>(AppConfiguration);
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

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
