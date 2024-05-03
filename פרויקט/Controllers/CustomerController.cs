using DAL.DalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IBLCustomer bl;
        public CustomerController(BLManager bl)
        {
            this.bl = bl.BLCustomer;
        }
        [HttpGet]
        public Customer GetCustomerById(string id)
        {
            return 
        }
    }
}
