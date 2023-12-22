using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mod = Models;
using System.Data;
using dam = DataAccessManager.Operations;
using DataAccessManager.Interface;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Models;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyFlatsBillsController : ControllerBase
    {
        ISocietyFlatsBills IsocietyFlatBills = null;
        mod.SocietyFlatsBills flatsBills = null;
        public SocietyFlatsBillsController()
        {
            flatsBills = new mod.SocietyFlatsBills();
            IsocietyFlatBills = new dam.SocietyFlatsBills();
        }

        [HttpGet]
        [Route("SocietyFlatsBills/SocietyBillDetails")]
        public IActionResult GetSocietyBillsDetails([FromBody] mod.FlatDetails flatDetails)
        {
            try
            {
                var data = IsocietyFlatBills.GetFlatsForSocietyBills(flatDetails.Society, flatDetails);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                flatsBills.ID = Convert.ToInt32(data.Tables[0].Rows[0]["ID"]);
                flatsBills.TotalAmount = Convert.ToDouble(data.Tables[0].Rows[0]["TotalAmount"]);
                flatsBills.BillIssueDate = Convert.ToDateTime(data.Tables[0].Rows[0]["BillIssueDate"]);
                flatsBills.BillDueDate = Convert.ToDateTime(data.Tables[0].Rows[0]["BillDueDate"]);
                flatsBills.Remarks = Convert.ToString(data.Tables[0].Rows[0]["Remarks"]);
                return Ok(flatsBills);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("SocietyFlatsBills/AddSocietyBill")]
        public IActionResult Add([FromBody] mod.SocietyFlatsBills societyFlatsBills)
        {
            try
            {
                IsocietyFlatBills.Add(societyFlatsBills.Society, null, societyFlatsBills);
                return Ok(societyFlatsBills);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("SocietyFlatsBills/UpdateSocietyBill")]
        public IActionResult Update([FromBody] mod.SocietyFlatsBills societyFlatsBills)
        {
            try
            {
                IsocietyFlatBills.Update(societyFlatsBills.Society, null, societyFlatsBills);
                return Ok(societyFlatsBills);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
