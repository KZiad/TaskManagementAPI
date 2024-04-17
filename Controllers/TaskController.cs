using Task_Management.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management.Models;

namespace Task_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id) 
        {
            TaskItem task = _taskService.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll([FromQuery] StatusEnum? status, [FromQuery] int? year, [FromQuery] int? month, [FromQuery] int? day)
        {
            List<TaskItem> tasks = _taskService.GetAllTasks(status, year, month, day);
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(CreateTaskRequest task) 
        {
            TaskItem newTask = _taskService.CreateTask(task);
            return Ok(newTask);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTask(int id, UpdateTaskRequest task)
        {
            TaskItem newTask = _taskService.UpdateTask(id, task);
            if (newTask == null)
            {
                return NotFound();
            }
            return Ok(newTask);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTask(int id)
        {
            if (_taskService.DeleteTask(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
