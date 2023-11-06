using System.ComponentModel.DataAnnotations;

namespace programming009.LibraryManagementWeb.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string ErrorMessage { get; set; } = "";
    }
}
