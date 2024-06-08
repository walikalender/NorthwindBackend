using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetList();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _orderService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            _orderService.Add(order);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _orderService.GetById(id).Data;
            _orderService.Delete(deletedEntity);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update(Order order)
        {
            _orderService.Update(order);
            return Ok();
        }
    }
}
