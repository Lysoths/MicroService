using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using orderApi.Models;
using orderApi.Services;



namespace orderApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        OrderService orderServices;



        public orderController()
        {
            orderServices = new OrderService();
        }


        [HttpPost("InsertOrder")]
        public  IActionResult InsertOrder(Order order)
        {
            
            var data = orderServices.InsertOrder(order);
            return Ok(data);
        }

        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(Order order)
        {
            var data = orderServices.DeleteOrder(order);
            return Ok(data);
        }

        [HttpPut("UpdateOrder")]
        public  IActionResult UpdateOrder(Order order)
        {
            var data = orderServices.UpdateOrder(order);
          
            return Ok(data);
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = orderServices.GetAll();
            return Ok(data);
        }

        [HttpGet("GetCustomerOrderCount/{id}")]
        public IActionResult GetCustomerOrderCount(int id)
        {
            var data = orderServices.GetCustomerOrderCount(id);
            return Ok(data.Count);
        }

        [HttpGet("getOrdersByCustomerId/{id}")]
        public IActionResult getOrdersByCustomerId(int id)
        {
            var data = orderServices.getOrdersByCustomerId(id);
            return Ok(data);
        }

        [HttpGet("getOrdersByProductId/{id}")]
        public IActionResult getOrdersByProductId(int id)
        {
            var data = orderServices.getOrdersByProductId(id);
            if(data.Count > 0)
            {
                return Ok(data);
            }
            else
            {
                return Ok("Bu üründen herhangi bir sipariş olmamıştır.");
            }
            
        }

        [NonAction]
        [CapSubscribe("order.add")]
        public void AddCustomerFromCap(Order order)
        {
            order.Description = "Yeni veri girişi oldu";
            var data = orderServices.UpdateOrder(order);
        }


  


            
      





    }








}

