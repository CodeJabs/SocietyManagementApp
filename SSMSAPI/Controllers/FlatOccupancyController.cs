using DataAccessManager.Interface;
using DataAccessManager.Operations;
using Microsoft.AspNetCore.Mvc;
using mod = Models;
using System.Data;
using dam = DataAccessManager.Operations;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatOccupancyController : ControllerBase
    {
        mod.FlatOccupancyMaster flatOccupancyMaster = null;
        IFlatOccupanyMaster IflatOccupancyMaster = null;
        public FlatOccupancyController()
        {
            flatOccupancyMaster = new mod.FlatOccupancyMaster();
            IflatOccupancyMaster = new dam.FlatOccupancyMaster();
        }

        [HttpGet]
        [Route("FlatOccupancy/OccupancyList")]

        public IActionResult GetFlatOccupancyList()
        {
            try
            {
                var data = IflatOccupancyMaster.GetFlatOccupancyType();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                List<mod.FlatOccupancyMaster> flatOccupancyMasters = new List<mod.FlatOccupancyMaster>();
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    flatOccupancyMasters.Add(new mod.FlatOccupancyMaster { ID = Convert.ToInt32(item["ID"]), OccupancyType = Convert.ToString("OccupancyType") });
                }

                return Ok(flatOccupancyMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("FlatOccupancy/Add")]

        public IActionResult AddNewFlatOccupancy([FromBody] mod.FlatOccupancyMaster flatOccupancyMaster)
        {
            try
            {
                var data = IflatOccupancyMaster.Save(flatOccupancyMaster);

                return Ok(flatOccupancyMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
