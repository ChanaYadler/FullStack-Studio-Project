using DAL.DalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.BlApi;
using BL;

namespace SERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IBLCustomer bl;
        public CustomerController(BLManager bl)
        {
            this.bl = bl.Customer;
        }
        [HttpGet("sign{id}")]
        public bool GetTypeof(string id) {
            if (bl.Type(id)) { return true; } return false;
        }
        [HttpGet("{id}")]
        public ActionResult< BLCustomer>  GetCustomerById(string id)
        {
            var c= bl.getALLDetails(id);
            if (c == null) return NotFound();
            return Ok(bl.getALLDetails(id));       
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerById(string id)
        {
            var b= bl.deleteCustomer(id);
            if (!b)
                return NotFound();
            return Ok();
        }
        [HttpPost]
        public IActionResult PostCustomer([FromBody]BLCustomer customer) {
            var c = bl.updateDetailsCustomer(customer);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
        [HttpPut]
        public IActionResult PutCustomer([FromBody]BLCustomer customer)
        {
            var c = bl.addNewCustomer(customer);
            if (!c)
                return NotFound();
            return Ok();
        }

    }
}
