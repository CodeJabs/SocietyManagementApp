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
    public class UserMasterController : ControllerBase
    {
        IUserMaster IuserMaster = null;
        mod.UserMaster userMaster = null;
        public UserMasterController()
        {
            IuserMaster = new dam.UserMaster();
            userMaster =new mod.UserMaster();

        }

        [HttpGet]
        [Route("UserMaster/UserTypes")]
        public IActionResult GetUserTypes([FromBody] mod.UserMaster userMaster)
        {
            try
            {
                var data = IuserMaster.GetUserMasterList(userMaster.Society, userMaster.UserID);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.UserMaster> userMasters = new List<mod.UserMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    userMasters.Add(new mod.UserMaster { UserID = Convert.ToInt32(dr["UserID"]), UserName = Convert.ToString(dr["UserName"]) });
                }
                return Ok(userMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("UserMaster/NewUser")]
        public IActionResult AddNewUser([FromBody] mod.UserMaster userMaster)
        {
            try
            {
                IuserMaster.Add(userMaster);
                
                return Ok(userMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("UserMaster/UpdateUser")]
        public IActionResult UpdateUser([FromBody] mod.UserMaster userMaster)
        {
            try
            {
                IuserMaster.Update(userMaster);

                return Ok(userMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("UserMaster/UserDetails")]
        public IActionResult GetUserDetails([FromBody] mod.UserMaster userMaster)
        {
            try
            {
                var data = IuserMaster.GetUserMasterDetails(userMaster.Society, userMaster.UserID);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                userMaster.FirstName = Convert.ToString(data.Tables[0].Rows[0]["FirstName"]);
                userMaster.LastName = Convert.ToString(data.Tables[0].Rows[0]["LastName"]);
                userMaster.UserID = Convert.ToInt32(data.Tables[0].Rows[0]["UserID"]);
                userMaster.MobileNo = Convert.ToInt32(data.Tables[0].Rows[0]["MobileNo"]);
                userMaster.EmailId = Convert.ToString(data.Tables[0].Rows[0]["EmailAddress"]);                
                return Ok(userMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


    }
}
