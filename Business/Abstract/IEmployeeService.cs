using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<Employee>> GetList();
        IResult Add(Employee employee);

        IResult Delete(Employee employee);

        IResult Update(Employee employee);
        IDataResult<Employee> GetById(int employeeId);
    }
}
