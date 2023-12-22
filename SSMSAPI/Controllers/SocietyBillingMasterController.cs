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
    public class SocietyBillingMasterController : ControllerBase
    {
        ISocietyBillingMaster IsocietyBillingMaster = null;
        mod.SocietyBillingMaster societyBillingMaster = null;
        public SocietyBillingMasterController()
        {
            societyBillingMaster = new mod.SocietyBillingMaster();
            IsocietyBillingMaster = new dam.SocietyBillingMaster();
        }

        [HttpGet]
        [Route("SocietyBillingMaster/SocietyBillingInformation")]
        public IActionResult GetSocietyBillingDetails([FromBody] mod.Society society)
        {
            try
            {
                var data = IsocietyBillingMaster.GetBillingMasterDetails(society);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                societyBillingMaster.SGST = Convert.ToDouble(data.Tables[0].Rows[0]["SGST"]);
                societyBillingMaster.CGST = Convert.ToDouble(data.Tables[0].Rows[0]["CGST"]);
                societyBillingMaster.TotalPrice = Convert.ToDouble(data.Tables[0].Rows[0]["TotalPrice"]);
                societyBillingMaster.Electricity = Convert.ToDouble(data.Tables[0].Rows[0]["Electricity"]);
                societyBillingMaster.Water = Convert.ToDouble(data.Tables[0].Rows[0]["Water"]);
                societyBillingMaster.Property = Convert.ToDouble(data.Tables[0].Rows[0]["Property"]);
                societyBillingMaster.OtherExpenses = Convert.ToDouble(data.Tables[0].Rows[0]["OtherExpenses"]);
                return Ok(societyBillingMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("SocietyBillingMaster/AddSocietyBilling")]
        public IActionResult AddSocietyBillingInformation([FromBody] mod.SocietyBillingMaster societyBillingMaster) 
        {
            try
            {
                IsocietyBillingMaster.Add(societyBillingMaster.Society, societyBillingMaster);
                
                return Ok(societyBillingMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("SocietyBillingMaster/UpdateSocietyBilling")]
        public IActionResult UpdateSocietyBillingInformation([FromBody] mod.SocietyBillingMaster societyBillingMaster)
        {
            try
            {
                IsocietyBillingMaster.Update(societyBillingMaster.Society, societyBillingMaster);

                return Ok(societyBillingMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
