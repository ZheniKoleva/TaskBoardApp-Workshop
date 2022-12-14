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

        int GetUserTasksCount(string userId);

        int GetAllTasksCount();

        Task<IEnumerable<HomeBoardViewModel>> GetBoardsTasks(IEnumerable<string> boardNames);

        Task<TaskViewModel> GetTaskToDelete(int id);

        Task DeleteTask(int id, string userId);
    }
}
