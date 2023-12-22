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
    public class FlatBillingMasterController : ControllerBase
    {

        IFlatsBillingMaster IflatsBillingMaster = null;
        mod.FlatsBillingMaster billingMaster = null;
        public FlatBillingMasterController()
        {
            billingMaster = new mod.FlatsBillingMaster();
            IflatsBillingMaster = new dam.FlatsBillingMaster();
        }

        [HttpGet]
        [Route("FlatBillingMaster/GetMaster")]       
        public IActionResult GetBillingMaster([FromBody] mod.FlatDetails flatDetails)
        {
            try
            {
                var data = IflatsBillingMaster.GetFlatBillingDetails(flatDetails);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.FlatsBillingMaster> flatsBillingMasters = new List<mod.FlatsBillingMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    flatsBillingMasters.Add(
                        new mod.FlatsBillingMaster {
                            NonOccupancyCharges = Convert.ToDouble(dr["NONOccupancyCharges"]),
                            CGST = Convert.ToDouble(dr["CGST"]),
                            SGST = Convert.ToDouble(dr["SGST"]),
                            ElectricityCharges = Convert.ToDouble(dr["ElectricityCharges"]),
                            FlatTransferCharges = Convert.ToDouble(dr["FlatTransferCharges"]),
                            InterestCharges = Convert.ToDouble(dr["InterestCharges"]),
                            ParkingCharges = Convert.ToDouble(dr["ParkingCharges"]),
                            Penalty = Convert.ToDouble(dr["Penalty"]),
                            PropertyTax = Convert.ToDouble(dr["PropertyTax"]),
                            ServiceCharges = Convert.ToDouble(dr["ServiceCharges"]),
                            StandardPricing = Convert.ToDouble(dr["StandardPricing"]),
                            Type = Convert.ToString(dr["Type"]),
                            Id = Convert.ToInt32(dr["ID"])
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
        [Route("FlatBillingMaster/Add")]

        public IActionResult Save([FromBody] mod.FlatsBillingMaster flatsBillingMaster)
        {
            try
            {
                IflatsBillingMaster.Add(flatsBillingMaster.FlatDetails, flatsBillingMaster);
                return Ok(flatsBillingMaster);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("FlatBillingMaster/Update")]
        public IActionResult UpdateFlatBilling([FromBody] mod.FlatsBillingMaster flatsBillingMaster)
        {
            try
            {
                IflatsBillingMaster.Update(flatsBillingMaster.FlatDetails, flatsBillingMaster);
                return Ok(flatsBillingMaster);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
