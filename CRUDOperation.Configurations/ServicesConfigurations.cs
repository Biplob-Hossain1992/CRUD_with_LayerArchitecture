using CRUDOperation.Abstractions.BLL;
using CRUDOperation.Abstractions.Repositories;
using CRUDOperation.BLL;
using CRUDOperation.DatabaseContext;
using CRUDOperation.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDOperation.Configurations
{
    public class ServicesConfigurations
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<DbContext, CRUDOperationDbContext>();
        }
    }
}
