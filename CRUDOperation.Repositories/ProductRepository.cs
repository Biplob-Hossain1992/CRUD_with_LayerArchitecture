using CRUDOperation.DatabaseContext;
using CRUDOperation.Models;
using CRUDOperation.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUDOperation.Repositories
{
    public class ProductRepository:EFRepository<Product>
    {
        private CRUDOperationDbContext _db;

        public ProductRepository(DbContext dbContext):base(dbContext)
        {
            _db = dbContext as CRUDOperationDbContext;
        }
        

        public List<Product> GetByCategory(int categoryId) /*Dropdown List Binding*/
        {
            return _db.Products.Where(c => c.CategoryId == categoryId).ToList();
        }


        public bool ProductExists(int? Id)
        {
            if (_db.Products.Any(id => id.Id == Id))
            {
                return true;
            }
            return false;
        }
    }
}



