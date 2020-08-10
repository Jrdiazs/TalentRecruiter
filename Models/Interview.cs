using Dapper;
using System;

namespace Models
{
    [Table("Interview")]
    public class Interview
    {
        [Key]
        [Column("InterviewId")]
        public int InterviewId { get; set; }

        [Column("InterviewStartTime")]
        public DateTime InterviewStartTime { get; set; }

        [Column("InterviewFinalTime")]
        public DateTime InterviewFinalTime { get; set; }

        [Column("TechnologyDetailId")]
        public int TechnologyDetailId { get; set; }

        [Column("TypeInterviewId")]
        public int TypeInterviewId { get; set; }

        [Column("Observation")]
        public string Observation { get; set; }

        [Column("CandidateId")]
        public int CandidateId { get; set; }

        [Column("DateCreation")]
        public DateTime? DateCreation { get; set; }

        [Column("DateUpdate")]
        public DateTime? DateUpdate { get; set; }

        [NotMapped]
        public Candidate Candidate { get; set; }

        [NotMapped]
        public InterviewType InterviewType { get; set; }

        [NotMapped]
        public TechnologyDetail TechnologyDetail { get; set; }
    }
}