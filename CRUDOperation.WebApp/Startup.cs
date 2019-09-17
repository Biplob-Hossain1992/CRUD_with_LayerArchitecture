using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CRUDOperation.DatabaseContext;
using CRUDOperation.Repositories;
using CRUDOperation.Abstractions.BLL;
using CRUDOperation.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using CRUDOperation.BLL;
using CRUDOperation.Configurations;
using AutoMapper;
using System;

namespace CRUDOperation.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            ServicesConfigurations.ConfigureServices(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "Default",
            //        template: "{controller=Customer}/{action=Create}/{id?}");
            //});


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Product}/{action=Create}/{id?}");
            });

        }
    }
}
