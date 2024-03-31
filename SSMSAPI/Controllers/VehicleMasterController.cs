using DataAccessManager.Interface;
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
    public class VehicleMasterController : ControllerBase
    {
        IVehicleMaster IvehicleMaster = null;
        mod.VehicleMaster vehicleMaster = null;
        public VehicleMasterController()
        {
            IvehicleMaster = new dam.VehicleMaster();
            vehicleMaster = new mod.VehicleMaster();
        }

        [HttpGet]
        [Route("VehicleMaster/VehicleMasterList")]
        public IActionResult GetVehicleMasters()
        {
            try
            {
                var data = IvehicleMaster.GetVehicleMasterList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.VehicleMaster> vehicleMasters = new List<mod.VehicleMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    vehicleMasters.Add(new mod.VehicleMaster { ID = Convert.ToInt32(dr["ID"]), VehicleType = Convert.ToString(dr["VehicleType"]) });

                }
                return Ok(vehicleMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("VehicleMaster/AddVehicleMaster")]
        public IActionResult AddVehicleMasters([FromBody] mod.VehicleMaster vehicleMaster)
        {
            try
            {
                 IvehicleMaster.Add(vehicleMaster);   
                
                return Ok(vehicleMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("VehicleMaster/UpdateVehicleMaster")]
        public IActionResult UpdateVehicleMasters([FromBody] mod.VehicleMaster vehicleMaster)
        {
            try
            {
                IvehicleMaster.Update(vehicleMaster);

                return Ok(vehicleMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
