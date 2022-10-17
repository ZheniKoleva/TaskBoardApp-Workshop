namespace TaskBoardApp.Core.Models
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }

        public IEnumerable<HomeBoardViewModel> BoardsWithTasksCount { get; set; }
            = new List<HomeBoardViewModel>();

        public int UserTasksCount { get; set; }
    }
}
