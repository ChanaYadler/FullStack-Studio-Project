using BL.BlApi;
using BL;
using DAL.DalModels;
using Microsoft.AspNetCore.Mvc;

namespace SERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IBLWorker bl;
        public WorkerController(BLManager bl)
        {
            this.bl = bl.Worker;
        }
        [HttpGet("sign{id}")]
        public bool GetTypeof(string id)
        {
            if (bl.Type(id)) { return true; }
            return false;
        }
        [HttpGet("{id}")]
        public ActionResult< Worker>GetWorkerById(string id)
        {
            var w = bl.GetDetailsById(id);
            if (w == null) { return NotFound(); }
            return Ok(bl.GetDetailsById(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkerById(string id)
        {
            var b = bl.deleteWorker(id);
            if (!b)
                return NotFound();
            return Ok();
        }
        [HttpPost]
        public IActionResult PostWorker([FromBody] BLWorker worker)
        {
            var c = bl.updateDetailsWorker(worker);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
        [HttpPut]
        public IActionResult PutWorker([FromBody] BLWorker worker)
        {
            var c = bl.addNewWorker(worker);
            if (!c)
                return NotFound();
            return Ok();
        }

    }
}

