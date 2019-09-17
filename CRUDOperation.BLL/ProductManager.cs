using CRUDOperation.Abstractions.BLL;
using CRUDOperation.Abstractions.Repositories;
using CRUDOperation.BLL.Base;
using CRUDOperation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDOperation.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
