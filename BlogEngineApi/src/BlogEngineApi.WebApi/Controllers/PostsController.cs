using BlogEngineApi.Application.Interfaces;
using BlogEngineApi.Domain.Dtos.Result;

using Microsoft.AspNetCore.Mvc;

namespace BlogEngineApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostAppService postAppService;

        public PostsController(IPostAppService postAppService)
        {
            this.postAppService = postAppService;
        }

        /// <summary>
        /// Gets posts
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <response code="200">Posts found. A JSON array representing the posts is returned</response>
        /// <response code="401">API Key was not provided</response>
        /// <response code="401">Unauthorized client</response>
        /// <response code="401">Invalid JWT Token</response>
        /// <response code="404">Posts not found</response>
        /// <response code="500">Internal server error. An exception has been thrown and its message is returned</response>
        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PostsResultDto), 200)]
        [ProducesResponseType(typeof(ErrorResultDto), 400)]
        [ProducesResponseType(typeof(IActionResult), 401)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        [ProducesResponseType(typeof(ErrorResultDto), 500)]
        public IActionResult GetAll()
        {
            var result = postAppService.GetAll();

            if (result == null)
            {
                return NotFound(null);
            }

            return Ok(result);
        }
    }
}
