using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetList();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            _customerService.Add(customer);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _customerService.GetById(id).Data;
            _customerService.Delete(deletedEntity);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {
            _customerService.Update(customer);
            return Ok();
        }
    }
}
