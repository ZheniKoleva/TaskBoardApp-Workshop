using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Data.Common;
using TaskBoardApp.Core.Data.Models;
using TaskBoardApp.Core.Models;

namespace TaskBoardApp.Core.Services
{
    public class BoardService : IBoardService
    {  
        private readonly IRepository repo;

        public BoardService(IRepository _repo)
        {            
            repo = _repo;
        }

        public async Task<IEnumerable<BoardViewModel>> GetAllBoards()
        {
            return await repo.All<Board>()
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks.Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskBoardModel>> GetBoardsTypes()
        {
            return await repo.All<Board>()
               .Select(b => new TaskBoardModel()
               {
                   Id = b.Id,
                   Name = b.Name
               })
               .ToListAsync();
        }


        public async Task<IEnumerable<string>> GetDistinctBoards()
        {
            return await repo.AllReadonly<Board>()
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();
        }       
    }
}
