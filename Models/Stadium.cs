using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Suburb { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public bool IsActive { get; set; }


        public virtual List<Team> Teams { get; set; }
    }
}
