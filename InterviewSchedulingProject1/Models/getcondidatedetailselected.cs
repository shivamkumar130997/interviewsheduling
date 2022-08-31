using System.ComponentModel.DataAnnotations;

namespace InterviewSchedulingProject1.Models
{
    public class getcondidatedetailselected
    {

        [Key]
        public int id { get; set; }

        public string? Password { get; set; }

        public string? username { get; set; }

        public string? firstname { get; set; }
        public string? lastname { get; set; }

        public string? phoneno { get; set; }

        public Nullable<int> Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }


        public string? Role { get; set; }

        public float? tenth { get; set; }

        public float? twelth { get; set; }

        public float? graduation { get; set; }


        public float? postgraduation { get; set; }

        public string? skills { get; set; }

        public float? Experince { get; set; }
        public bool? selected { get; set; }
        public string? Company { get; set; }

    }
}
