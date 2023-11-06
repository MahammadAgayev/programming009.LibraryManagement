using System.ComponentModel.DataAnnotations;

namespace programming009.LibraryManagementWeb.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string ErrorMessage { get; set; } = "";
    }
}
