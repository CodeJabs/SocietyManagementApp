using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mod = Models;
using System.Data;
using dam = DataAccessManager.Operations;
using DataAccessManager.Interface;
using Models;
using DataAccessManager.Operations;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatTypeMasterController : ControllerBase
    {
        mod.FlatTypeMaster flatTypeMaster = null;
        IFlatTypeMaster IFlatTypeMaster = null;
        public FlatTypeMasterController()
        {
            flatTypeMaster = new mod.FlatTypeMaster();
            IFlatTypeMaster = new dam.FlatTypeMaster();
        }

        [HttpGet]
        [Route("FlatTypeMasterController/GetFlatsTypeList")]
        public IActionResult GetBillingMaster()
        {
            try
            {
                var data = IFlatTypeMaster.GetFlatTypeMasterList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.FlatTypeMaster> flatsBillingMasters = new List<mod.FlatTypeMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    flatsBillingMasters.Add(
                        new mod.FlatTypeMaster
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FlatType = Convert.ToString(dr["FlatType"]),
                            StandardCharges = Convert.ToDecimal(dr["StandardCharges"])

                        });
                }

                return Ok(flatsBillingMasters);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }


        }
        [HttpPost]
        [Route("FlatTypeMasterController/AddNewFlatType")]

        public IActionResult Add([FromBody] mod.FlatTypeMaster flatTypeMaster)
        {
            try
            {
                IFlatTypeMaster.Save(flatTypeMaster);
                return Ok(flatTypeMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPut]
        [Route("FlatTypeMasterController/UpdateFlatTypeRecords")]
        public IActionResult Update([FromBody] mod.FlatTypeMaster flatTypeMaster)
        {
            try
            {
                IFlatTypeMaster.Update(flatTypeMaster);
                return Ok(flatTypeMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }

}
