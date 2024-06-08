using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController(IOrderDetailService orderDetailService) : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService = orderDetailService;

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderDetailService.GetList();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _orderDetailService.GetByOrderId(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(OrderDetail orderDetail)
        {
            _orderDetailService.Add(orderDetail);
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var deletedEntity = _orderDetailService.GetByOrderId(id).Data;
            _orderDetailService.Delete(deletedEntity);
            return Ok();
        }
        [HttpPut("update")]
        public IActionResult Update(OrderDetail orderDetail)
        {
            _orderDetailService.Update(orderDetail);
            return Ok();
        }
    }
}
