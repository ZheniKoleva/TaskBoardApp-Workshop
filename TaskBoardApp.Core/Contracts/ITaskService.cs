using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Core.Models;


namespace TaskBoardApp.Core.Contracts
{
    public interface ITaskService
    {   
        Task AddTask(TaskFormModel model, string UserId);

        Task<TaskDetailsViewModel> GetTaskDetails(int id);

        Task<Data.Models.Task> GetTaskToEdit(int id);

        Task UpdateTask(int id, string userId, TaskFormModel model);
    }
}
