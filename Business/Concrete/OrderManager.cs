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
    public class OrderManager(IOrderDal orderDal) : IOrderService
    {
        private readonly IOrderDal _orderDal = orderDal;
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult();
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult();
        }

        public IDataResult<Order> GetById(int orderId)
        {
            var result = _orderDal.Get(o => o.OrderID==orderId);
            return new SuccessDataResult<Order>(result);
        }

        public IDataResult<List<Order>> GetList()
        {
            var result = _orderDal.GetList().ToList();
            return new SuccessDataResult<List<Order>>(result);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult();
        }
    }
}
