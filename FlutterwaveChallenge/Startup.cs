using FlutterwaveChallenge.Appsettings;
using FlutterwaveChallenge.Data.Implementation;
using FlutterwaveChallenge.Data.Interface;
using FlutterwaveChallenge.Repositories.Implementation;
using FlutterwaveChallenge.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterwaveChallenge
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
            services.AddControllers();
            services.Configure<Appsetting>(Configuration.GetSection(nameof(Appsetting)));
            services.AddSingleton<IAppsetting>(sp =>
            sp.GetRequiredService<IOptions<Appsetting>>().Value
            );
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<IRiderRepository, RiderRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "V1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "flutter wave Api", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "flutter wave  API V1");

            });
        }
    }
}
