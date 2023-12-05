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
    public class SocietyNominationRegisterController : ControllerBase
    {
        ISocietyNominationRegister IsocietyNomination = null;
        mod.SocietyNominationRegister societyNomination = null;
        public SocietyNominationRegisterController()
        {
            IsocietyNomination = new dam.SocietyNominationRegister();
            societyNomination = new mod.SocietyNominationRegister();
        }

        [HttpPost]
        [Route("SocietyNominationRegister/AddNomination")]
        public IActionResult AddNomination(mod.SocietyNominationRegister societyNominationRegister)
        {
            try
            {
                IsocietyNomination.Add(societyNominationRegister);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("SocietyNominationRegister/UpdateNomination")]
        public IActionResult UpdateNomination(mod.SocietyNominationRegister societyNominationRegister)
        {
            try
            {
                IsocietyNomination.Update(societyNominationRegister);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
