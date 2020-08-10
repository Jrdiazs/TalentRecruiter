using Dapper;

namespace Models
{
    [Table("InterviewType")]
    public class InterviewType
    {
        [Key]
        [Column("TypeInterviewId")]
        public int TypeInterviewId { get; set; }

        [Column("TypeInterviewDescripction")]
        public string TypeInterviewDescripction { get; set; }
    }
}