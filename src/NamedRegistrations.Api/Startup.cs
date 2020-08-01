using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NamedRegistrations.Application;
using NamedRegistrations.Infrastructure;
using AutoMapper;
using NamedRegistrations.Domain.Services;
using NamedRegistrations.Domain;

namespace NamedRegistrations.Api
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
            services.AddAutoMapper(typeof(Startup));

            // Repositories
            services.AddTransient<ICarRepository, CarRepository>();

            // Domain services
            services.AddTransient<IEngineValidator, EngineValidator>();

            // Option 0 - UNWANTED dependency on Microsoft.Extensions.DependencyInjection
            services.AddTransient<ICarAppService0, CarAppService0>();
            services.AddTransient<ICarValidatorFactory0, CarValidatorFactory0>();
            services.AddTransient<SedanCarValidator0>();
            services.AddTransient<CoupeCarValidator0>();
            services.AddTransient<HatchbackCarValidator0>();
            services.AddTransient<SuvCarValidator0>();
            services.AddTransient<VanCarValidator0>();

            // Option 1 - Factory approach
            services.AddTransient<ICarAppService1, CarAppService1>();
            services.AddTransient<ICarValidatorFactory1, CarValidatorFactory1>();
            services.AddTransient<ICarValidator1, SedanCarValidator1>();
            services.AddTransient<ICarValidator1, CoupeCarValidator1>();
            services.AddTransient<ICarValidator1, HatchbackCarValidator1>();
            services.AddTransient<ICarValidator1, SuvCarValidator1>();
            services.AddTransient<ICarValidator1, VanCarValidator1>();

            // Option 2 - Function-resolver approach
            services.AddTransient<ICarAppService2, CarAppService2>();
            services.AddTransient<SedanCarValidator2>();
            services.AddTransient<CoupeCarValidator2>();
            services.AddTransient<HatchbackCarValidator2>();
            services.AddTransient<SuvCarValidator2>();
            services.AddTransient<VanCarValidator2>();
            services.AddTransient<Func<CarType, ICarValidator2>>(services => carType =>
            {
                return carType switch
                {
                    CarType.Sedan => services.GetService<SedanCarValidator2>(),
                    CarType.Coupe => services.GetService<CoupeCarValidator2>(),
                    CarType.Hatchback => services.GetService<HatchbackCarValidator2>(),
                    CarType.Suv => services.GetService<SuvCarValidator2>(),
                    CarType.Van => services.GetService<VanCarValidator2>(),
                    _ => null,
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
