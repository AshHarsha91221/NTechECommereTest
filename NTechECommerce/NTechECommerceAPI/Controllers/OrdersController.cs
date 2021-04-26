using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTechECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpPost("createOrder")]
        public async Task<IActionResult> createOrder(Models.CreateOrderReq requestModel)
        {

            try
            {
                Helpers.Orders obj = new Helpers.Orders();
                var data = obj.createOrder(requestModel);

                return Ok(data);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Exist") > -1)
                    return BadRequest("Customer Doesn't Exist.");
                else
                    return BadRequest("Something went wrong.");
            }

        }

        [HttpGet("getOrders")]
        public async Task<IActionResult> getOrders(int pageIndex, int pageSize)
        {

            try
            {
                Helpers.Orders obj = new Helpers.Orders();
                var data = obj.getOrders(pageIndex, pageSize);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong.");
            }

        }

    }
}
