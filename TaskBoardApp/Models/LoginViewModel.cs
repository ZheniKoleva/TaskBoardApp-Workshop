using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Core.Constants;

namespace TaskBoardApp.Models
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Username")]
        [StringLength(DataConstants.User.MaxUsername)]
        public string Username { get; set; } = null!;

        [Required]       
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        
        public string? ReturnUrl { get; set; }

    }
}
