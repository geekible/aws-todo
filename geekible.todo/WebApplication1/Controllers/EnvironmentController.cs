using geekible.todo.logic.contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly ILogger<EnvironmentController> _logger;
        private readonly IBuildEnvironment _buildEnvironment;

        public EnvironmentController(ILogger<EnvironmentController> logger,
            IBuildEnvironment buildEnvironment)
        {
            _logger = logger;
            _buildEnvironment = buildEnvironment;
        }

        [HttpPut(Name = "BuildEnvironment")]
        public async Task<IActionResult> BuildEnvironment()
        {
            await _buildEnvironment.Build();
            return Ok();
        }

    }
}
