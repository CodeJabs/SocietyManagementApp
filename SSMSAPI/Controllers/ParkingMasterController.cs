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
    public class ParkingMasterController : ControllerBase
    {
        mod.ParkingMaster parkingMaster = null;
        IParkingMaster IparkingMaster = null;
        public ParkingMasterController()
        {
            parkingMaster = new mod.ParkingMaster();
            IparkingMaster = new dam.ParkingMaster();
        }

        [HttpGet]
        [Route("ParkingMaster/GetParkingList")]
        public IActionResult GetList()
        {
            try
            {
                var data = IparkingMaster.GetParkingMasterList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.ParkingMaster> parkingMasters = new List<mod.ParkingMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    parkingMasters.Add(new mod.ParkingMaster { ID = Convert.ToInt32(dr["ID"]), ParkingType = Convert.ToString(dr["ParkingType"]) });
                }

                return Ok(parkingMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("ParkingMaster/SaveParkingMaster")]
        public IActionResult Save([FromBody]mod.ParkingMaster parkingMaster)
        {
            try
            {
                IparkingMaster.Add(parkingMaster);
                return Ok(parkingMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
 }
