using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSchedulingProject1.Models
{
    public class CondidateDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int canditateid { get; set; }
        [Display(Name = "10 th")]

        public float? tenth { get; set; }
        [Display(Name = "12 th")]

        public Nullable<float> twelth { get; set; }
        [Display(Name = "graduation")]

        public float? graduation { get; set; }
        [Display(Name = "Post-graduation")]

        public float? postgraduation { get; set; }
        [Display(Name = "Skills")]


        [MaxLength(1000)]
        public string? skills { get; set; }
        [Display(Name = "Company Name")]


        [MaxLength(1000)]
        public string? Company { get; set; }
        [Display(Name = "Experince")]

        public float? Experince { get; set; }

        public int? Candidateid { get; set; }
        [ForeignKey("Candidateid")]
        public virtual CandidateUser id { get; set; }

    }
}
