using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Core.Contracts;

namespace TaskBoardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService _boardService)
        {
            boardService = _boardService;
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
           var boards = await boardService.GetAllBoards();

            return View(boards);
        }
    }
}
