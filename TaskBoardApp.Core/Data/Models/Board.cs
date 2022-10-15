using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Core.Constants;

namespace TaskBoardApp.Core.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Board.MaxBoardName)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
