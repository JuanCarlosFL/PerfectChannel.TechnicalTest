using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TaskController(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoTask>>> GetAll()
        {
            var todoList = await _todoTaskRepository.GetAllTasksAsync();

            return Ok(todoList);
        }

        [HttpGet("{id}")]
        [ActionName("GetTodoTaskById")]
        public async Task<ActionResult<TodoTask>> GetTodoTaskById(int id)
        {
            var task = await _todoTaskRepository.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TodoTask>> PostTodoTAsk(TodoTask task)
        {
            var todoTask = await _todoTaskRepository.PostTaskAsync(task);

            return Ok(todoTask);
        }
    }
}