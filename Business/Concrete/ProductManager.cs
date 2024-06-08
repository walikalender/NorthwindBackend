using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    [LogAspect(typeof(FileLogger))]
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;

        [CacheRemoveAspect(pattern: "IProductService.Get")]
        [CacheRemoveAspect(pattern: "ICategoryService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(ProductMessages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(ProductMessages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDal.Get(p => p.ProductID==productId);
            return new SuccessDataResult<Product>(result, ProductMessages.ProductGet);
        }

        [PerformanceAspect(1)]
        public IDataResult<List<Product>> GetList()
        {
            Thread.Sleep(5000);
            var result = _productDal.GetList().ToList();
            return new SuccessDataResult<List<Product>>(result, ProductMessages.ProductsListed);
        }

       // [SecuredOperation("Product.GetList,Admin")]
        [CacheAspect(duration: 1)]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            var result = _productDal.GetList(p => p.CategoryID==categoryId).ToList();
            return new SuccessDataResult<List<Product>>(result, ProductMessages.ProductsListed);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(ProductMessages.ProductUpdated);
        }

        [CacheRemoveAspect(pattern: "IProductService.GetList")]
        [CacheRemoveAspect(pattern: "ICategoryService.GetList")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(ProductMessages.ProductUpdated);
        }
    }
}
