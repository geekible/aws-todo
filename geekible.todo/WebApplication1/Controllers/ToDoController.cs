using geekible.todo.logic.contracts;
using geekible.todo.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoLogic _logic;

        public ToDoController(ILogger<ToDoController> logger, IToDoLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(ToDo toDo)
        {
            try
            {
                toDo = await _logic.Create(toDo);
                return Ok(toDo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet(Name = "GetModel")]
        public IActionResult GetModel()
        {
            return Ok(new ToDo());
        }
    }
}
