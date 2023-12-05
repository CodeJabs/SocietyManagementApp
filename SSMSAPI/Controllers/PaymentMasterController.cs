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
    public class PaymentMasterController : ControllerBase
    {
        IPaymentMaster IpaymemtMaster = null;
        mod.PaymentMaster paymentMaster = null;
        public PaymentMasterController()
        {
            paymentMaster = new mod.PaymentMaster();
            IpaymemtMaster = new dam.PaymentMaster();
        }

        [HttpGet]
        [Route("PaymentMaster/GetPaymentType")]
        public IActionResult GetPaymentMaster()
        {
            try
            {
                var data = IpaymemtMaster.GetPaymentMasterList();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.PaymentMaster> paymentMasters = new List<mod.PaymentMaster>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    paymentMasters.Add(new mod.PaymentMaster { ID = Convert.ToInt32(dr["ID"]), paymentType = Convert.ToString(dr["Type"]) });
                }
                return Ok(paymentMasters);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("PaymentMaster/NewPaymentType")]
        public IActionResult AddPaymentMaster([FromBody] mod.PaymentMaster paymentMaster)
        {
            try
            {
                IpaymemtMaster.Add(paymentMaster);                
                return Ok(paymentMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("PaymentMaster/UpdatePaymentType")]
        public IActionResult UpdatePaymentMaster([FromBody] mod.PaymentMaster paymentMaster)
        {
            try
            {
                IpaymemtMaster.Update(paymentMaster);
                return Ok(paymentMaster);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
