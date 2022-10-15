using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Data.Common;
using TaskBoardApp.Core.Data.Models;
using TaskBoardApp.Core.Models;
using Task = TaskBoardApp.Core.Data.Models.Task;

namespace TaskBoardApp.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository repo;

        public TaskService(IRepository _repo)
        {
            repo = _repo;
        }

        public async System.Threading.Tasks.Task Add(TaskFormModel model, string userId)
        {           

            Task task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = userId,
            };

            await repo.AddAsync(task);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskBoardModel>> GetBoards()
        {
            return await repo.AllReadonly<Board>()
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                })
                .ToListAsync();
        }
    }
}
