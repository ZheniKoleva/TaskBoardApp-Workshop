using TaskBoardApp.Core.Models;

namespace TaskBoardApp.Core.Contracts
{
    public interface IBoardService
    {
        public Task<IEnumerable<BoardViewModel>> GetAllBoards();
    }
}
