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
    public class OccupancyMasterController : ControllerBase
    {
        mod.OccupancyMaster occupancyMaster = null;
        IOccupancyMaster IOccupancyMaster = null;
        public OccupancyMasterController()
        {
            occupancyMaster = new mod.OccupancyMaster();
            IOccupancyMaster = new dam.OccupancyMaster();
        }

        [HttpGet]
        [Route("OccupancyMaster/GetOccupancyList")]
        public IActionResult GetList()
        {
            try
            {
                var data = IOccupancyMaster.GetOccupancyList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.FlatOccupancyMaster> flatOccupancyMasters = new List<mod.FlatOccupancyMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    flatOccupancyMasters.Add(new mod.FlatOccupancyMaster {ID = Convert.ToInt32(dr["ID"]),OccupancyType = Convert.ToString(dr["OccupancyType"]) }
                    );
                }
                return Ok(flatOccupancyMasters);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("OccupancyMaster/SaveOccupancy")]
        public IActionResult Save([FromBody] mod.OccupancyMaster occupancyMaster)
        {
            try
            {
                IOccupancyMaster.Add(occupancyMaster);
                return Ok(occupancyMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
