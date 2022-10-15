using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Core.Constants;

namespace TaskBoardApp.Core.Data.Models
{
    public class User : IdentityUser
    {     
        [Required]
        [MaxLength(DataConstants.User.MaxUserFirstName)]
        public string FirstName { get; init; } = null!;

        [Required]
        [MaxLength(DataConstants.User.MaxUserLastName)]
        public string LastName { get; init; } = null!;
    }
}
