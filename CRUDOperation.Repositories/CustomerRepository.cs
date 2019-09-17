using CRUDOperation.Abstractions.Repositories;
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
    public class CustomerRepository:EFRepository<Customer>,ICustomerRepository
    {

        private CRUDOperationDbContext _db;

        public CustomerRepository(DbContext dbContext):base(dbContext)
        {
            _db = dbContext as CRUDOperationDbContext;
        }
       

        public bool CustomerExists(int? Id)
        {
            if (_db.Customers.Any(id => id.Id == Id))
            {
                return true;
            }
            return false;
        }
    }
}
