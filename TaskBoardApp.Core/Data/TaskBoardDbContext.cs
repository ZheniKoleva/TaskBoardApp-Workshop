using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Core.Configuration;
using TaskBoardApp.Core.Data.Models;
using Task = TaskBoardApp.Core.Data.Models.Task;

namespace TaskBoardApp.Data
{
    public class TaskBoardDbContext : IdentityDbContext
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Boards { get; init; }

        public DbSet<Task> Tasks { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.ApplyConfiguration<User>(new UserConfiguration());
            //builder.ApplyConfiguration<Board>(new BoardConfiguration());
            //builder.ApplyConfiguration<Task>(new TaskConfiguration());

            base.OnModelCreating(builder);
        }
    }
}