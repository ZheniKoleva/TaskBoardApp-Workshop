namespace TaskBoardApp.Core.Models
{
    public class TaskDetailsViewModel : TaskViewModel
    {
        public string CreatedOn { get; init; } = null!;

        public string Board { get; init; } = null!;
    }
}
