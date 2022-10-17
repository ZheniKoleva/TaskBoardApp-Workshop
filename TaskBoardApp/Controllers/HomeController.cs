using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Models;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {       
        private readonly ITaskService taskService;

        private readonly IBoardService boardService;

        public HomeController(
            ITaskService _taskService,
            IBoardService _boardService)
        {
            taskService = _taskService;
            boardService = _boardService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            var boardsNames = await boardService.GetDistinctBoards();

            var taskCounts = await taskService.GetBoardsTasks(boardsNames);

            var userTasksCount = -1;

            if (User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                userTasksCount = taskService.GetUserTasksCount(userId);
            }

            model.AllTasksCount = taskService.GetAllTasksCount();
            model.BoardsWithTasksCount = taskCounts;
            model.UserTasksCount = userTasksCount;         

            return View(model);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}