using System.ComponentModel.DataAnnotations;

namespace InterviewSchedulingProject1.Models
{
    public class RegisterUser
    {
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required(ErrorMessage = "The Password is required")]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password required")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "User Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "The User Name is required")]
        public string username { get; set; }
    }
}
