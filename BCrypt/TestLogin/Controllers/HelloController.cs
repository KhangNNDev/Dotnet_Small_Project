using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TestLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [Authorize(Policy = "ADMIN")]
        [HttpGet]
        public IActionResult Hello()
        {
            var message = "heelo thang";
            Console.WriteLine(message);
            return Ok(message);
        }

        [Authorize(Policy = "USER")]
        [HttpGet("conkec")]
        public IActionResult Hello2()
        {
            var message = "heelo con kec";
            Console.WriteLine(message);
            return Ok(message);
        }
    }
}
