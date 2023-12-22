using DataAccessManager.Interface;
using DataAccessManager.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mod=Models;
using System.Data;
using dam = DataAccessManager.Operations;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatPaymentsController : ControllerBase
    {

        mod.FlatPayments flatPayments = null;
        IFlatPayments IflatPayments = null;
        public FlatPaymentsController()
        {
            flatPayments = new mod.FlatPayments();
            IflatPayments = new dam.FlatPayments();
        }

        [HttpGet]
        [Route("FlatPayments/PaymentList")]
        public IActionResult GetFlatPaymentList([FromBody] Models.FlatDetails flatDetails)
        {
            try
            {
                var data = IflatPayments.GetFlatPaymentList(flatDetails);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                List<mod.FlatPayments> flatPayments = new List<mod.FlatPayments>();
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    flatPayments.Add(new mod.FlatPayments { ID = Convert.ToInt32(item["ID"]), InvoiceID = Convert.ToInt32("InvoiceID") });
                }

                return Ok(flatPayments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("FlatPayments/Details")]
        public IActionResult GetFlatPaymentDetails([FromBody] mod.FlatPayments flatPayments)
        {
            try
            {
                var data = IflatPayments.GetFlatPaymentDetails(flatPayments.FlatDetails, flatPayments);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                
                flatPayments.Society.Name = Convert.ToString(data.Tables[0].Rows[0]["SocietyName"]);
                flatPayments.UserMaster.FirstName = Convert.ToString(data.Tables[0].Rows[0]["FirstName"]);
                flatPayments.UserMaster.LastName = Convert.ToString(data.Tables[0].Rows[0]["LastName"]);
                flatPayments.FlatDetails.FlatNo = Convert.ToInt32(data.Tables[0].Rows[0]["FlatNo"]);               

                return Ok(flatPayments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("FlatPayments/SaveFlatPayment")]
        public IActionResult AddNewFlatpayement([FromBody] mod.FlatPayments flatPayments)
        {
            try
            {
                var data = IflatPayments.Add(flatPayments, flatPayments.FlatDetails, flatPayments.PaymentMaster, flatPayments.UserMaster);
                
                return Ok(flatPayments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("FlatPayments/EditFlatPayment")]
        public IActionResult Update([FromBody] mod.FlatPayments flatPayments)
        {
            try
            {
                var data = IflatPayments.Update(flatPayments, flatPayments.FlatDetails, flatPayments.PaymentMaster, flatPayments.UserMaster);

                return Ok(flatPayments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
