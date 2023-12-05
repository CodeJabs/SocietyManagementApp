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
    public class SocietyCommiteeMembersController : ControllerBase
    {

        ISocietyComitteeMembers IsocietyComiteeMem = null;
        mod.SocietyComitteeMembers comitteeMembers = null;
        public SocietyCommiteeMembersController()
        {
            comitteeMembers = new mod.SocietyComitteeMembers();
            IsocietyComiteeMem = new dam.SocietyComitteeMembers();
        }

        [HttpGet]
        [Route("SocietyCommiteeMembers/CommiteeMembersList")]

        public IActionResult GetCommiteeMembers([FromBody] mod.UserMaster userMaster)
        {
            try
            {
                var data = IsocietyComiteeMem.GetCommitteeMembers(userMaster);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.SocietyComitteeMembers> societyComitteeMembers = new List<mod.SocietyComitteeMembers>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societyComitteeMembers.Add(new mod.SocietyComitteeMembers
                    {
                        ID = Convert.ToInt32(dr["ID"])
                        
                    });
                }

                return Ok(societyComitteeMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SocietyCommiteeMembers/AddCommiteeMember")]
        public IActionResult AddSocietyCommiteeeMember([FromBody] mod.SocietyComitteeMembers societyComitteeMembers)
        {
            try
            {
                IsocietyComiteeMem.Add(societyComitteeMembers);

                return Ok(societyComitteeMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("SocietyCommiteeMembers/UpdateCommiteeMember")]
        public IActionResult UpdateSocietyCommiteeeMember([FromBody] mod.SocietyComitteeMembers societyComitteeMembers)
        {
            try
            {
                IsocietyComiteeMem.Update(societyComitteeMembers);

                return Ok(societyComitteeMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
