using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Entities;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTaskController : ControllerBase
    {
        private readonly IMyTaskService _myTaskService;

        public MyTaskController(IMyTaskService myTaskService) {
            _myTaskService = myTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var myTask = await _myTaskService.GetAllTasks();
            return Ok(myTask);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var myTask = await _myTaskService.GetTaskById(id);
            if(myTask == null)
            {
                return NotFound();
            }
            return Ok(myTask);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MyTask myTask)
        {
            var createTask = await _myTaskService.CreateTask(myTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = createTask.Id }, createTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MyTask updatedTask)
        {
            int existingTask = await _myTaskService.UpdateTask(id, updatedTask);
            if(existingTask == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int myTask = (int)await _myTaskService.DeleteTask(id);
            if(myTask == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
