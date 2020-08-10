using Dapper;

namespace Models
{
    [Table("TechnologyDetail")]
    public class TechnologyDetail
    {
        [Key]
        [Column("TechnologyDetailId")]
        public int TechnologyDetailId { get; set; }

        [Column("TechnologyId")]
        public int? TechnologyId { get; set; }

        [Column("TechnologyDescription")]
        public string TechnologyDescription { get; set; }

        [Column("TechnologyOrderId")]
        public int? TechnologyOrderId { get; set; }

        [NotMapped]
        public Technology Technology { get; set; }
    }
}