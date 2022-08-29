using System.ComponentModel.DataAnnotations;
using UserManagementSystemAPI.DataLayer.DTOs.Request;

namespace UserManagementSystemAPI.DataLayer.DTOs
{
    public class UserRequestDto 
    {
        [Required]
        [StringLength(20, ErrorMessage = "FirstName must be between {2} and {1} characters long.", MinimumLength = 4)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "LastName must be between {2} and {1} characters long.", MinimumLength = 4)]
        public string LastName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "UserName must be between {2} and {1} characters long.", MinimumLength = 4)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string ConfirmPassword { get; set; }
        public string? Role { get; set; }
        public string Status { get; set; }

        //[EnumDataType(typeof(Role))]
        //public string Role { get; set; }
    }
}
