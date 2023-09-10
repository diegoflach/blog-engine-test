using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using BlogEngineApi.Application.Interfaces;
using BlogEngineApi.Domain.Dtos;
using BlogEngineApi.Domain.Dtos.Result;

namespace BlogEngineApi.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            this.loginAppService = loginAppService;
        }

        /// <summary>
        /// Required authentication method
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>JWT token</returns>
        /// <response code="200">Successful login attempt. A JSON object with JWT Token is returned</response>
        /// <response code="400">Bad email format</response>
        /// <response code="401">Invalid login attempt</response>
        /// <response code="500">Internal server error. An exception has been thrown and its message is returned</response>
        [HttpPost(Name = "Login")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LoginResultDto), 200)]
        [ProducesResponseType(typeof(ErrorResultDto), 400)]
        [ProducesResponseType(typeof(ErrorResultDto), 401)]
        [ProducesResponseType(typeof(ErrorResultDto), 500)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            return Ok(await loginAppService.Login(loginDto));
        }
    }
}