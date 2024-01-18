using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
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
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;

        public IResult Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(),product);
            // Business Codes
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

        public IDataResult<List<Product>> GetList()
        {
            var result = _productDal.GetList().ToList();
            return new SuccessDataResult<List<Product>>(result, ProductMessages.ProductsListed);
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            var result = _productDal.GetList(p => p.CategoryID==categoryId).ToList();
            return new SuccessDataResult<List<Product>>(result, ProductMessages.ProductsListed);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(ProductMessages.ProductUpdated);
        }
    }
}
