using TaskBoardApp.Core.Models;

namespace TaskBoardApp.Core.Contracts
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardViewModel>> GetAllBoards();

        Task<IEnumerable<TaskBoardModel>> GetBoardsTypes();

        Task<IEnumerable<string>> GetDistinctBoards();
        
    }
}
