using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mod = Models;
using System.Data;
using dam = DataAccessManager.Operations;
using DataAccessManager.Interface;
using Microsoft.AspNetCore.Rewrite;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMasterController : ControllerBase
    {
        IRoleMaster IroleMaster = null;
        mod.RoleMaster roleMaster = null;
        public RoleMasterController()
        {
            roleMaster = new mod.RoleMaster();
            IroleMaster =new dam.RoleMaster();
        }

        [HttpGet]
        [Route("RoleMaster/GetRoleType")]
        public IActionResult GetRoleMaster()
        {
            try
            {
                var data = IroleMaster.GetRoleMasterList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.RoleMaster> roleMasters = new List<mod.RoleMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    roleMasters.Add(new mod.RoleMaster { ID = Convert.ToInt32(dr["ID"]), RoleName = Convert.ToString(dr["Type"]) });
                }
                return Ok(roleMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("RoleMaster/NewRoleMastewr")]
        public IActionResult AddRoleMaster([FromBody] mod.RoleMaster roleMaster)
        {
            try
            {
                IroleMaster.Add(roleMaster);
                return Ok(roleMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("RoleMaster/UpdateRoleMaster")]
        public IActionResult UpdatePaymentMaster([FromBody] mod.RoleMaster roleMaster)
        {
            try
            {
                IroleMaster.Update(roleMaster);
                return Ok(roleMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
