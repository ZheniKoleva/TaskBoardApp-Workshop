using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Core.Constants;

namespace TaskBoardApp.Core.Models
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.Task.MaxTaskTitle, MinimumLength = DataConstants.Task.MinTaskTitle,
            ErrorMessage = DataConstants.Task.TaskErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Task.MaxTaskDescription, MinimumLength = DataConstants.Task.MinTaskDescription,
            ErrorMessage = DataConstants.Task.TaskErrorMessage)]
        public string Description { get; set; } = null!;


        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
    }
}
