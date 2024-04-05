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

        public IActionResult GetParkingRecord(int FlatId,int SocietyID)
        {
            try
            {
                var data = IparkingRecords.GetParkingRecord(FlatId, SocietyID);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.ParkingRecords> parkingRecords = new List<mod.ParkingRecords>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    parkingRecords.Add(new mod.ParkingRecords {FlatDetails =new mod.FlatDetails { FlatNo = Convert.ToInt32(dr["FlatNo"]) },
                        ID = Convert.ToInt32(dr["ID"]),
                        ParkingCharges = Convert.ToInt32(dr["ParkingCharges"]),
                        ParkinghNo = Convert.ToString(dr["ParkingNo"]),
                        VehicleNumber = Convert.ToString(dr["VehicleNumber"]),
                        VehicleType = Convert.ToString(dr["VehicleType"])

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
        public IActionResult AddNewParking([FromBody] mod.ParkingRecords parkingRecords)
        {
            try
            {
                IparkingRecords.Add(parkingRecords.FlatDetails, parkingRecords.VehicleMaster, parkingRecords);
                return Ok(parkingRecords);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("ParkingRecords/UpdateAllotedParking")]
        public IActionResult UpdateParking([FromBody] mod.ParkingRecords parkingRecords)
        {
            try
            {
                IparkingRecords.Update(parkingRecords.FlatDetails, parkingRecords.VehicleMaster, parkingRecords);
                return Ok(parkingRecords);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
