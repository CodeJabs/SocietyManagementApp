using DataAccessManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data;
using dam = DataAccessManager.Operations;
namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyController : ControllerBase
    {
        Society society = null;
        ISociety ISociety = null;
        public SocietyController()
        {
            society = new Society();
            ISociety = new  dam.Society();

        }

        [HttpGet]
        [Route("Society/GetSocieties")]

        public IActionResult GetAllSocieties()
        {
            try
            {
                var data = ISociety.GetSocieties();
                if (data.Tables == null) { return NotFound("Error ! Failed To get Records"); }
                if (data.Tables[0].Rows.Count == 0) { return NotFound("No Records Found."); }

                List<Society> societies = new List<Society>();

                foreach (DataRow dr in data.Tables[0].Rows)
                {
                    societies.Add(new Society
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                    });
                }
                return Ok(societies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            finally { }

            
        }

        [HttpPost]
        [Route("Society/AddNewSocitey")]

        public IActionResult Save([FromBody] Society society)
        {
            try
            {
                ISociety.Save(society);
                return Ok(society);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {

                //DisposeInstances();
            }
        }
    }
}
