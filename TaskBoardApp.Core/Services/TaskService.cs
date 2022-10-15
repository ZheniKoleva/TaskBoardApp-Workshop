﻿using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Core.Contracts;
using TaskBoardApp.Core.Data.Common;
using TaskBoardApp.Core.Models;
using Task = TaskBoardApp.Core.Data.Models.Task;

namespace TaskBoardApp.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepository repo;

        private IBoardService boardService;

        public TaskService(IRepository _repo,
            IBoardService _boardService)
        {
            repo = _repo;
            boardService = _boardService;
        }

        public async System.Threading.Tasks.Task AddTask(TaskFormModel model, string userId)
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

        public async Task<TaskDetailsViewModel> GetTaskDetails(int id)
        {
            return await repo.All<Task>(t => t.Id == id)                 
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();                           
        }

        public async Task<Data.Models.Task> GetTaskToEdit(int id)
        {
            return await repo.GetByIdAsync<Task>(id);
                
        }

        public async System.Threading.Tasks.Task UpdateTask(int id, string userId, TaskFormModel model)
        {
            var taskToUpdate = await repo.GetByIdAsync<Task>(id);

            taskToUpdate.Title = model.Title;
            taskToUpdate.Description = model.Description;
            taskToUpdate.BoardId = model.BoardId;

            repo.Update<Task>(taskToUpdate);
            await repo.SaveChangesAsync();
        }
    }
}
