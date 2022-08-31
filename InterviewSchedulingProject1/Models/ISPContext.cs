using Microsoft.EntityFrameworkCore;

namespace InterviewSchedulingProject1.Models
{
    public class ISPContext : DbContext
    {
        public ISPContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CandidateUser> CandidateUser { get; set; }
        public DbSet<CondidateDetails> condidateDetails { get; set; }

        public DbSet<getcondidatedetailselected> candidateFullDetails { get; set; }

    }
}
