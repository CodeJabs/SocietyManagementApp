using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Test/Welcome")]

        public IActionResult WelcomeMessage()
        {
            return Ok("Welcome to SSMS API, This Test Message");
        }

    }
}
