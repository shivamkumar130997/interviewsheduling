using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSchedulingProject1.Models
{
    public class CandidateFullDetailsCopy
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Required(ErrorMessage = "The Password is required")]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Display(Name = "User Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "The User Name is required")]
        public string username { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "The First Name is required")]
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "The Last Name is required")]
        public string lastname { get; set; }

        [Display(Name = "PhoneNo")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string phoneno { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "The Gender  is required")]
        public Nullable<int> Gender { get; set; }

        [Display(Name = "DOB")]
        [Required(ErrorMessage = "The DOB  is required")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Display(Name = "Role")]

        public string Role { get; set; }


        [Display(Name = "10 th")]

        [Required(ErrorMessage = "The 10 th percentage  is required")]
        public float? tenth { get; set; }

        [Display(Name = "12 th")]

        [Required(ErrorMessage = "The 10 th percentage  is required")]
        public float? twelth { get; set; }

        [Display(Name = "graduation")]

        [Required(ErrorMessage = "The graduation percentage is required")]
        public float? graduation { get; set; }

        [Display(Name = "Post-graduation")]

        public float? postgraduation { get; set; }

        [Display(Name = "Skills")]

        [Required(ErrorMessage = "The Skills is required")]
        [MaxLength(1000)]
        public string? skills { get; set; }

        [Display(Name = "Experince")]

        [Required(ErrorMessage = "The Experince is required")]
        public float? Experince { get; set; }
        public bool? Selected { get; set; }
        [Display(Name = "Company Name")]

        [Required(ErrorMessage = "The Company Name is required")]
        [MaxLength(1000)]
        public string? Company { get; set; }





    }
}
