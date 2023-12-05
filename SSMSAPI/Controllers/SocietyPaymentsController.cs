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
    public class SocietyPaymentsController : ControllerBase
    {
        ISocietyPayments IsocietyPayments = null;
        mod.SocietyPayments societyPayment = null;
        public SocietyPaymentsController()
        {
            IsocietyPayments = new dam.SocietyPayments();
            societyPayment = new mod.SocietyPayments();

        }

        [HttpGet]
        [Route("SocietyPayments/GetSocietyPayments")]
        public IActionResult GetSocietyPayementsList([FromBody] mod.Society society)
        {
            try
            {
                var data = IsocietyPayments.GetSocietyPayments(society);
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }
                List<mod.SocietyPayments> societyPayments = new List<mod.SocietyPayments>();
                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societyPayments.Add(new mod.SocietyPayments { 
                        InvoiceID = Convert.ToInt32(dr["InvoiceID"]), 
                        FromDate = Convert.ToDateTime(dr["FromDate"]),
                        ToDate = Convert.ToDateTime(dr["ToDate"]),
                        UserMaster =new mod.UserMaster {UserName = Convert.ToString(dr["UserName"]) }
                    });
                }
                return Ok(societyPayments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("SocietyPayments/AddSocietyPayementsDetails")]
        public IActionResult AddSocietyPayementsDetails([FromBody] mod.SocietyPayments societyPayments)
        {
            try
            {
               IsocietyPayments.Add(societyPayments);
               
                return Ok(societyPayments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("SocietyPayments/UpdateSocietyPayementsDetails")]
        public IActionResult UpdateSocietyPayementsDetails([FromBody] mod.SocietyPayments societyPayments)
        {
            try
            {
                IsocietyPayments.Update(societyPayments);

                return Ok(societyPayments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
