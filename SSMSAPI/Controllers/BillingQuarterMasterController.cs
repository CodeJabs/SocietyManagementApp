using DataAccessManager.Interface;
using dam=DataAccessManager.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mod = Models;
using System.Data;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingQuarterMasterController : ControllerBase
    {

        IBillingQuarterMaster IbillingQuarterMaster = null;
        mod.BillingQuaterMaster BillingQuaterMaster = null;
        public BillingQuarterMasterController()
        {
            IbillingQuarterMaster = new dam.BillingQuarterMaster();
            BillingQuaterMaster = new mod.BillingQuaterMaster();
        }

        [HttpGet]
        [Route("BillingQuarterMaster/GetQuarterList")]
        public IActionResult GetQuarterList()
        {
            try
            {
                var data = IbillingQuarterMaster.GetQuarterList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.BillingQuaterMaster> billingQuaterMasters = new List<mod.BillingQuaterMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    billingQuaterMasters.Add(
                        new mod.BillingQuaterMaster
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            QuaterType = Convert.ToString(dr["QuarterType"])
                            

                        });
                }

                return Ok(billingQuaterMasters);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("BillingQuarterMaster/Add")]
        public IActionResult Save([FromBody] mod.BillingQuaterMaster billingQuaterMaster)
        {
            
            try
            {
                IbillingQuarterMaster.Save(billingQuaterMaster);
            }
            catch (Exception)
            {
                return BadRequest("Not Added");
                throw;
            }

            return Ok("Added");

        }

        [HttpPut]
        [Route("BillingQuarterMaster/Update")]
        public IActionResult Update([FromBody] mod.BillingQuaterMaster billingQuaterMaster)
        {

            try
            {
                IbillingQuarterMaster.Update(billingQuaterMaster);
            }
            catch (Exception)
            {
                return BadRequest("Not Added");
                throw;
            }

            return Ok("Added");

        }
    }
}
