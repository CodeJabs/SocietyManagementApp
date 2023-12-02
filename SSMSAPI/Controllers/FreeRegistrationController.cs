using DataAccessManager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using dam= DataAccessManager.Operations;
namespace SSMSAPI.Controllers
{
    
    public class FreeRegistrationController : ControllerBase
    {

        FreeRegistration freeRegistration = null;
        IFreeRegistration IFreeRegistration = null;
        public FreeRegistrationController()
        {
            freeRegistration = new FreeRegistration();
            IFreeRegistration =new dam.FreeRegistration();
        }

        [HttpPost]
        [Route("FreeRegistration/Add")]
        public IActionResult AddNew([FromBody] FreeRegistration freeRegistration)
        {
            bool isAdded = false;
            try
            {
                isAdded=IFreeRegistration.Add(freeRegistration);
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
