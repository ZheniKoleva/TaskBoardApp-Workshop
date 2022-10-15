using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Models;

namespace TaskBoardApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;        

        public TaskController(ITaskService _taskService)
        {
            taskService = _taskService;
           
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TaskFormModel()
            {
                Boards = await taskService.GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await taskService.Add(model, userId);

            return RedirectToAction("All", "Board");
        }

       
    }
}
