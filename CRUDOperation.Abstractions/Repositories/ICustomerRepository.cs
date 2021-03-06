﻿using CRUDOperation.Abstractions.Repositories.Base;
using CRUDOperation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDOperation.Abstractions.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {

        bool CustomerExists(int? Id);
    }
}
