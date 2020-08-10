using Dapper;

namespace Models
{
    [Table("Technology")]
    public class Technology
    {
        [Key]
        [Column("TechnologyId")]
        public int TechnologyId { get; set; }

        [Column("TechnologyDescription")]
        public string TechnologyDescription { get; set; }
    }
}