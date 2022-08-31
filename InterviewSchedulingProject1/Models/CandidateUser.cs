using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSchedulingProject1.Models
{
    public class CandidateUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]

        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [NotMapped]

        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        public string? ConfirmPassword { get; set; }
        [Display(Name = "User Name")]
        [MaxLength(50)]

        public string? username { get; set; }
        [Display(Name = "First Name")]
        [MaxLength(100)]

        public string? firstname { get; set; }
        [Display(Name = "Last Name")]
        [MaxLength(100)]

        public string? lastname { get; set; }
        [Display(Name = "PhoneNo")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? phoneno { get; set; }
        [Display(Name = "Gender")]
        public int? Gender { get; set; }

        [Display(Name = "DOB")]
        public System.DateTime? DOB { get; set; }
        [Display(Name = "Role")]

        public string? Role { get; set; }
        public bool? selected { get; set; }
        public System.DateTime? InterviewTiming { get; set; }





    }
}
