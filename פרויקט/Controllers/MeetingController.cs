using BL.BlApi;
using BL;
using DAL.DalModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        IBLMeeting bl;
        public MeetingController(BLManager bl)
        {
            this.bl = bl.Meeting;
        }
        [HttpGet("{id}")]
        public ActionResult< List<Meeting>> GetMeetingById(string id)
        {
            var m = bl.getDetailsById(id);
            if (m == null) { return NotFound(); }
            return Ok(bl.getDetailsById(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMeetingById(string id)
        {
            var b = bl.deleteMeeting(id);   
            if (!b)
                return NotFound();
            return Ok();
        }
        [HttpPost]
        public IActionResult PostMeeting([FromBody] BLMeeting meeting)
        {
            var c = bl.updateDetailsMeeting(meeting);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
        [HttpPut]
        public IActionResult PutMeeting([FromBody] BLMeeting meeting)
        {
            var c = bl.addNewMeeting(meeting);
            if (!c)
                return NotFound();
            return Ok();
        }

    }
}

