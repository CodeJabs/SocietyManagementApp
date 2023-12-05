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
    public class VisitorTypeMasterController : ControllerBase
    {

        IVisitorTypeMaster IvisitorTypeMaster = null;
        mod.VisitorTypeMaster visitorTypemaster = null;

        public VisitorTypeMasterController()
        {
            IvisitorTypeMaster = new dam.VisitorTypeMaster();
            visitorTypemaster =new mod.VisitorTypeMaster();
        }

        [HttpGet]
        [Route("VisitorTypeMaster/GetVisitorsMasterList")]
        public IActionResult GetVisitorMasters()
        {
            try
            {
                var data = IvisitorTypeMaster.GetVisitorTypesList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.VisitorTypeMaster> visitorTypeMasters = new List<mod.VisitorTypeMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    visitorTypeMasters.Add(new mod.VisitorTypeMaster { ID = Convert.ToInt32(dr["ID"]), Type = Convert.ToString(dr["Type"]) });

                }
                return Ok(visitorTypeMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("VisitorTypeMaster/AddVisitorMaster")]
        public IActionResult AddVehicleMasters([FromBody] mod.VisitorTypeMaster visitorTypeMaster)
        {
            try
            {
                IvisitorTypeMaster.Add(visitorTypeMaster);

                return Ok(visitorTypeMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("VisitorTypeMaster/UpdateVisitorMaster")]
        public IActionResult UpdateVehicleMasters([FromBody] mod.VisitorTypeMaster visitorTypeMaster)
        {
            try
            {
                IvisitorTypeMaster.Update(visitorTypeMaster);

                return Ok(visitorTypeMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


    }
}
