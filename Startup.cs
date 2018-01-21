using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkVendingMachine.Business.Contract;
using DrinkVendingMachine.Business.Impl;
using DrinkVendingMachine.Data;
using DrinkVendingMachine.Data.Provider.Contract;
using DrinkVendingMachine.Data.Provider.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrinkVendingMachine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // framework services;
            services.AddDbContext<DataBaseContext>(options =>
                                                   options.UseSqlite("Data Source=VendingMachine.db")
                                                   ,ServiceLifetime.Transient);
            services.AddMvc();

            // Register application services.

            //providers
            services.AddTransient<ICatalogItemProvider, CatalogItemProvider>();
            services.AddTransient<ICoinStoreProvider, CoinStoreProvider>();
            services.AddTransient<IDrinkProvider, DrinkProvider>();

            //business
            services.AddTransient<IMoneyHandler, MoneyHandler>();

           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
