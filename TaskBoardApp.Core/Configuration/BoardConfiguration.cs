using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Core.Data.Models;


namespace TaskBoardApp.Core.Configuration
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            List<Board> boards = GetBoards();

            builder.HasData(boards);
        }

        private List<Board> GetBoards()
        {
            return new List<Board>()
            {
                new Board()
                {
                    Id = 1,
                    Name = "Open"                    
                },
                new Board()
                {
                    Id = 2,
                    Name = "In Progress"
                },
                 new Board()
                {
                    Id = 3,
                    Name = "Done"
                }
            };
        }
    }
}
