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
    
    [LogAspect(typeof(FileLogger))]
    public class EmployeeManager(IEmployeeDal employeeDal) : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal = employeeDal;
        [ValidationAspect(typeof(EmployeeValidator))]
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult();
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult();
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            var result = _employeeDal.Get(e => e.EmployeeID==employeeId);
            return new SuccessDataResult<Employee>(result);
        }

        public IDataResult<List<Employee>> GetList()
        {
            var result = _employeeDal.GetList().ToList();
            return new SuccessDataResult<List<Employee>>(result);
        }

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult();
        }
    }
}
