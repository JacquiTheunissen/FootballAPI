using System.ComponentModel.DataAnnotations;

namespace FootballAPI.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Suburb { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public Stadium Stadium { get; set; }

        public int? StadiumId { get; set; }

        public bool IsActive { get; set; }
    }
}
