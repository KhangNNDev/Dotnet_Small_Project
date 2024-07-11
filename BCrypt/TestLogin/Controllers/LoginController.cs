using Microsoft.AspNetCore.Mvc;
using TestLogin.Payload.Request;
using TestLogin.Payload.Response;
using TestLogin.Services;

namespace TestLogin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginRequest loginRequest)
        {
            var account = await _loginService.Login(loginRequest);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.Message = "Hello Thang";
            baseResponse.Data = account;
            if (account == null)
            {
                return BadRequest("Wrong account");
            }
            return Ok(baseResponse);
        }

        [HttpPost("login2")]
        public async Task<IActionResult> Login2([FromForm] LoginRequest loginRequest)
        {
            var account = await _loginService.Login(loginRequest);
            BaseResponse baseResponse = new BaseResponse();
            baseResponse.Message = "Hello Son";
            baseResponse.Data = account;
            if (account == null)
            {
                return BadRequest("Wrong account");
            }
            return Ok(baseResponse);
        }

    }
}
