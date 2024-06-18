using BL.BlApi;
using BL;
using DAL.DalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IBLRole bl;
        public RoleController(BLManager bl)
        {
            this.bl = bl.Role;
        }
        [HttpGet("{id}")]
        public ActionResult<List< Role> >GetRoleById(string id)
        {
            var r = bl.getDetailsById(id);
            if (r == null) { return NotFound(); }
            return Ok(bl.getDetailsById(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoleById(string id)
        {
            var b = bl.deleteRole(id);
            if (!b)
                return NotFound();
            return Ok();
        }
        [HttpPost]
        public IActionResult PostRole([FromBody] BLRole role)
        {
            var c = bl.updateDetailsRole(role);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
        [HttpPut]
        public IActionResult PutRole([FromBody] BLRole role)
        {
            var c = bl.addNewRole(role);
            if (!c)
                return NotFound();
            return Ok();
        }

    }
}

