using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mod = Models;
using System.Data;
using dam = DataAccessManager.Operations;
using DataAccessManager.Interface;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyMeetingRegisterController : ControllerBase
    {
        ISocietyMeetingRegister IsocietyMeetingReg = null;
        mod.SocietyMeetingRegister meetingRegister = null;

        public SocietyMeetingRegisterController()
        {
            IsocietyMeetingReg = new dam.SocietyMeetingRegister();
            meetingRegister = new mod.SocietyMeetingRegister();
        }

        [HttpGet]
        [Route("SocietyMeetingRegister/GetSocietyMeetings")]
        public IActionResult GetMeetings([FromBody] mod.Society society)
        {
            try
            {
                var data = IsocietyMeetingReg.GetSocietyMeetings(society);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.SocietyMeetingRegister> societyMeetingRegisters = new List<mod.SocietyMeetingRegister>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societyMeetingRegisters.Add(new mod.SocietyMeetingRegister { ID = Convert.ToInt32(dr["ID"]), MeetingSubject = Convert.ToString(dr["MeetingSubject"]) });
                }

                return Ok(societyMeetingRegisters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("SocietyMeetingRegister/AddSocietyMeetings")]
        public IActionResult Add([FromBody] mod.SocietyMeetingRegister societyMeetingRegister)
        {
            try
            {
                IsocietyMeetingReg.Add(societyMeetingRegister, societyMeetingRegister.Society);
                return Ok(societyMeetingRegister);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("SocietyMeetingRegister/UpdateSocietyMeetings")]
        public IActionResult Update([FromBody] mod.SocietyMeetingRegister societyMeetingRegister)
        {
            try
            {
                IsocietyMeetingReg.Update(societyMeetingRegister, societyMeetingRegister.Society);
                return Ok(societyMeetingRegister);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }

}
