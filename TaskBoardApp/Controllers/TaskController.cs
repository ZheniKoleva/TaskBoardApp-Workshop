using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Models;

namespace TaskBoardApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService; 
        
        private readonly IBoardService boardService;

        public TaskController(
            ITaskService _taskService,
            IBoardService _boardService)
        {
            taskService = _taskService;
            boardService = _boardService;
           
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var model = new TaskFormModel()
            {
                Boards = await boardService.GetBoardsTypes()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await taskService.AddTask(model, userId);

            return RedirectToAction("All", "Board");
        }
     
        public async Task<IActionResult> Details(int id)
        {
            var taskToShow = await taskService.GetTaskDetails(id);

            if (taskToShow == null)
            {
                return BadRequest();
            }

            return View(taskToShow);            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var taskToEdit = await taskService.GetTaskToEdit(id);            

            var boards = await boardService.GetBoardsTypes();

            if (taskToEdit == null || taskToEdit == null)
            {
                return BadRequest();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != taskToEdit.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel model = new TaskFormModel()
            {
                Title = taskToEdit.Title,
                Description = taskToEdit.Description,
                BoardId = taskToEdit.BoardId,
                Boards = boards
            };


            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {                
                return View();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await taskService.UpdateTask(id, userId, model);

            return RedirectToAction("All", "Board");

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id, TaskViewModel model)
        {
            var taskToDelete = await taskService.GetTaskToDelete(id);            

            if (taskToDelete == null)
            {
                return BadRequest();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != taskToDelete.Owner)
            {
                return Unauthorized();
            }  

            return View(taskToDelete);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = await taskService.GetTaskToDelete(id);

            if (taskToDelete == null)
            {
                return BadRequest();
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != taskToDelete.Owner)
            {
                return Unauthorized();
            }

            await taskService.DeleteTask(id, userId);

            return RedirectToAction("All", "Board");
        }
    }
}
