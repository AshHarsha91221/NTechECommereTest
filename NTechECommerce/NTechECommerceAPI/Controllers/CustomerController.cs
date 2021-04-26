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
    public class CustomerController : ControllerBase
    {

        [HttpPost("createUpdateCustomer")]
        public async Task<IActionResult> createUpdateCustomer(Models.CreateUpdateCustomerReq requestModel)
        {
            try
            {
                Helpers.Customer obj = new Helpers.Customer();
                var data = obj.createUpdateCustomer(requestModel);

                return Ok(data);
            }
            catch(Exception ex)
            {
                if(ex.Message.IndexOf("Email") > -1)
                    return BadRequest("Email Already Exists.");
                else if(ex.Message.IndexOf("Phone") > -1)
                    return BadRequest("Phone Already Exists.");
                else
                    return BadRequest("Something went wrong.");
            }
            
        }

    }
}
