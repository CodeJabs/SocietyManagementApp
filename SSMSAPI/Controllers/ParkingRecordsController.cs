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
    public class ParkingRecordsController : ControllerBase
    {
        mod.ParkingRecords parkingRecords = null;
        IParkingRecords IparkingRecords = null;
        public ParkingRecordsController()
        {
            parkingRecords = new mod.ParkingRecords();
            IparkingRecords =new dam.ParkingRecords();
        }

        [HttpGet]
        [Route("ParkingRecords/ParkingRecord")]

        public IActionResult GetParkingRecord([FromBody] mod.FlatDetails flatDetails)
        {
            try
            {
                var data = IparkingRecords.GetParkingRecord(flatDetails);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.ParkingRecords> parkingRecords = new List<mod.ParkingRecords>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    parkingRecords.Add(new mod.ParkingRecords { FlatDetails = flatDetails,
                        ID = Convert.ToInt32(dr["ID"]),
                        ParkingCharges = Convert.ToInt32(dr["ParkingCharges"]),
                        ParkinghNo = Convert.ToString(dr["ParkingNo"]),
                        VehicleNumber = Convert.ToString(dr["VehicleNumber"])                        
                    });
                }
                return Ok(parkingRecords);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("ParkingRecords/AllotParking")]
        public IActionResult AddNewParking([FromBody] mod.FlatDetails flatDetails, [FromBody] mod.VehicleMaster vehicleMaster, [FromBody] mod.ParkingRecords parkingRecords)
        {
            try
            {
                IparkingRecords.Add(flatDetails, vehicleMaster, parkingRecords);
                return Ok(parkingRecords);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("ParkingRecords/UpdateAllotedParking")]
        public IActionResult UpdateParking([FromBody] mod.FlatDetails flatDetails, [FromBody] mod.VehicleMaster vehicleMaster, [FromBody] mod.ParkingRecords parkingRecords)
        {
            try
            {
                IparkingRecords.Update(flatDetails, vehicleMaster, parkingRecords);
                return Ok(parkingRecords);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
