﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetList();
        IResult Add(Customer customer);

        IResult Delete(Customer customer);

        IResult Update(Customer customer);
        IDataResult<Customer> GetById(string customerId);
    }
}
