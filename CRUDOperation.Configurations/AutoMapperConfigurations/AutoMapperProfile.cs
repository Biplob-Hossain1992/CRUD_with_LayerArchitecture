using AutoMapper;
using CRUDOperation.Models;
using CRUDOperation.Models.RazorViewModels.Customer;
using CRUDOperation.Models.RazorViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDOperation.Configurations.AutoMapperConfigurations
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerCreateViewModel,Customer>();
            CreateMap<Customer,CustomerCreateViewModel>();
            CreateMap<ProductCreateViewModel, Product>();
            CreateMap<Product, ProductCreateViewModel>();
        }
    }
}
