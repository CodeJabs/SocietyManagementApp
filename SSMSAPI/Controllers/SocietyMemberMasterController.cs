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
    public class SocietyMemberMasterController : ControllerBase
    {
        ISocietyMemberMaster IsocietyMembermaster = null;
        mod.SocietyMemberMaster societyMemberMaster = null;
        public SocietyMemberMasterController()
        {
            IsocietyMembermaster = new dam.SocietyMemberMaster();
            societyMemberMaster = new mod.SocietyMemberMaster();
        }

        [HttpGet]
        [Route("SocietyMemberMaster/GetSocietyMembers")]
        public IActionResult GetMembers()
        {
            try
            {
                var data = IsocietyMembermaster.GetSocietyMemberMasterList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.SocietyMemberMaster> societyMemberMasters = new List<mod.SocietyMemberMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societyMemberMasters.Add(new mod.SocietyMemberMaster { ID = Convert.ToInt32(dr["ID"]), Type = Convert.ToString(dr["Type"]) });
                }
                return Ok(societyMemberMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SocietyMemberMaster/AddSocietyMembers")]
        public IActionResult AddMembers(mod.SocietyMemberMaster societyMemberMaster)
        {
            try
            {
                IsocietyMembermaster.Add(societyMemberMaster);
                return Ok(societyMemberMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("SocietyMemberMaster/UpdateSocietyMembers")]
        public IActionResult UpdateMembers(mod.SocietyMemberMaster societyMemberMaster)
        {
            try
            {
                IsocietyMembermaster.Update(societyMemberMaster);
                return Ok(societyMemberMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
