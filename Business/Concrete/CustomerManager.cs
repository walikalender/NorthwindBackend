using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager(ICustomerDal customerDal) : ICustomerService
    {
        private readonly ICustomerDal _customerDal = customerDal;
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var result = _customerDal.Get(c => c.CustomerID==customerId);
            return new SuccessDataResult<Customer>(result);
        }

        public IDataResult<List<Customer>> GetList()
        {
            var result = _customerDal.GetList().ToList();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
