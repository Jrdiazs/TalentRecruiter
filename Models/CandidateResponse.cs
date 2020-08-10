using Newtonsoft.Json;
using Tools;

namespace Models
{
    /// <summary>
    /// Modelo para el api http://jsonplaceholder.typicode.com/users
    /// </summary>
    [JsonConverter(typeof(JsonPathConverter))]
    public class CandidateResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int CandidateId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string CandidateName { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string CandidateEmail { get; set; }

        [JsonProperty(PropertyName = "address.street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "address.suite")]
        public string Suite { get; set; }

        [JsonProperty(PropertyName = "address.city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "address.zipcode")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "address.geo.lat")]
        public string GeoLat { get; set; }

        [JsonProperty(PropertyName = "address.geo.lng")]
        public string GeoIng { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "company.name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "company.catchPhrase")]
        public string CompanyCatchPhrase { get; set; }

        [JsonProperty(PropertyName = "company.bs")]
        public string CompanyBs { get; set; }
    }
}