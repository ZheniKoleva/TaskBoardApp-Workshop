using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Core.Constants;

namespace TaskBoardApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(DataConstants.User.MaxUsername)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Compare(nameof(ConfirmPassword))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [Display(Name = "First Name")]
        [StringLength(DataConstants.User.MaxUserFirstName)]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(DataConstants.User.MaxUserLastName)]
        public string LastName { get; set; } = null!;
    }
}
