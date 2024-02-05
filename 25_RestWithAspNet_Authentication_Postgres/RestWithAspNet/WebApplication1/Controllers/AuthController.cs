using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Business;
using RestWithAspNet.Data.VO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var token = _loginBusiness.ValidateCredentials(user);
            if (token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVO)
        {
            if (tokenVO is null) return BadRequest("Invalid client request");
            var token = _loginBusiness.ValidateCredentials(tokenVO);
            if (token == null) return BadRequest("Invalid client request");

            return Ok(token);
        }

        [HttpGet]
        [Authorize("Bearer")]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var userName = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(userName);
            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }
    }
}
