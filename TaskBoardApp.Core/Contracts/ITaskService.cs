using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Core.Models;


namespace TaskBoardApp.Core.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskBoardModel>> GetBoards();

        Task Add(TaskFormModel model, string UserId);

    }
}
