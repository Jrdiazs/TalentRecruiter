using Dapper;

namespace Models
{
    [Table("Candidate")]
    public class Candidate
    {
        [Key]
        [Column("CandidateId")]
        [Required]
        public int CandidateId { get; set; }

        [Column("CandidateName")]
        public string CandidateName { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("CandidateEmail")]
        public string CandidateEmail { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        [Column("Suite")]
        public string Suite { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("GeoLat")]
        public string GeoLat { get; set; }

        [Column("GeoIng")]
        public string GeoIng { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("Website")]
        public string Website { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("CompanyCatchPhrase")]
        public string CompanyCatchPhrase { get; set; }

        [Column("CompanyBs")]
        public string CompanyBs { get; set; }
    }
}