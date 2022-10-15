using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TaskBoardApp.Core.Data.Models.Task;

namespace TaskBoardApp.Core.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            List<Task> boards = GetTasks();

            builder.HasData(boards);
        }

        private List<Task> GetTasks()
        {
            return new List<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET Fundamentals exam",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "3f5122df-927f-4c78-97b4-09b893e16051",
                    BoardId = 1
                },
                new Task()
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Learn using EF Core and MS SQL Server Management Studio",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = "3f5122df-927f-4c78-97b4-09b893e16051",
                    BoardId = 3
                },
                 new Task()
                {
                    Id = 3,
                    Title = "Improve ASP.NET Core skills",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-10),
                    OwnerId = "3f5122df-927f-4c78-97b4-09b893e16051",
                    BoardId = 2
                },
                 new Task()
                {
                    Id = 4,
                    Title = "Prepare for C# Fundamentals Exam",
                    Description = "Prepare by solving old Mid and Final exams",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "3f5122df-927f-4c78-97b4-09b893e16051",
                    BoardId = 3
                }
            };
        }
    }
}
