using Business.Abstract;
using Business.Constants.Messages;
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
    [ValidationAspect(typeof(CategoryValidator))]
    [LogAspect(typeof(FileLogger))]
    public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
    {
        private readonly ICategoryDal _categoryDal = categoryDal;

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(CategoryMessages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(CategoryMessages.CategoryDeleted);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var result = _categoryDal.Get(c => c.CategoryID==categoryId);
            return new SuccessDataResult<Category>(result, CategoryMessages.CategoryGet);
        }

        public IDataResult<List<Category>> GetList()
        {
            var result = _categoryDal.GetList().ToList();
            return new SuccessDataResult<List<Category>>(result, CategoryMessages.CategoriesListed);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(CategoryMessages.CategoryUpdated);
        }
    }
}
