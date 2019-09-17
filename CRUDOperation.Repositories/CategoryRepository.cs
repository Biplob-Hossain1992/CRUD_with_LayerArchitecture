using CRUDOperation.DatabaseContext;
using CRUDOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUDOperation.Repositories
{
    public class CategoryRepository
    {
        private CRUDOperationDbContext _db;
        public CategoryRepository()
        {
            _db = new CRUDOperationDbContext();
        }
        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}