using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
    [ValidationAspect(typeof(OrderDetailValidator))]
    [LogAspect(typeof(FileLogger))]
    public class OrderDetailManager(IOrderDetailDal orderDetailDal) : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal = orderDetailDal;
        public IResult Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new SuccessResult();
        }

        public IResult Delete(OrderDetail orderDetail)
        {
            _orderDetailDal.Delete(orderDetail);
            return new SuccessResult();
        }

        public IDataResult<OrderDetail> GetByOrderId(int orderId)
        {
            var result = _orderDetailDal.Get(od => od.OrderID==orderId);
            return new SuccessDataResult<OrderDetail>(result);
        }

        public IDataResult<List<OrderDetail>> GetList()
        {
            var resullt = _orderDetailDal.GetList().ToList();
            return new SuccessDataResult<List<OrderDetail>>(resullt);
        }

        public IResult Update(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
            return new SuccessResult();
        }
    }
}
