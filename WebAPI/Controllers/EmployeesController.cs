using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetList();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {
            _employeeService.Add(employee);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _employeeService.GetById(id).Data;
            _employeeService.Delete(deletedEntity);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update(Employee employee)
        {
            _employeeService.Update(employee);
            return Ok();
        }
    }
}
