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
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;

        public IResult Add(Product product)
        {
            // Business Codes
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDal.Get(p => p.ProductID==productId);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetList()
        {
            var result = _productDal.GetList().ToList();
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            var result = _productDal.GetList(p => p.CategoryID==categoryId).ToList();
            return new SuccessDataResult<List<Product>>(result);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }
    }
}
