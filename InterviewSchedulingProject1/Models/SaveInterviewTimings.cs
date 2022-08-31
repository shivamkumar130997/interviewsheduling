using System.ComponentModel.DataAnnotations;

namespace InterviewSchedulingProject1.Models
{
    public class SaveInterviewTimings
    {
        public int? Candidateid { get; set; }
        [Required(ErrorMessage = "The Selection is required")]

        public bool? selected { get; set; }
        [Display(Name = "Company Name")]


        [MaxLength(1000)]

        [Required(ErrorMessage = "The Company is required")]
        public string? Company { get; set; }
        [Required(ErrorMessage = "The InterviewTiming is required")]
        public System.DateTime? InterviewTiming { get; set; }
    }
}
