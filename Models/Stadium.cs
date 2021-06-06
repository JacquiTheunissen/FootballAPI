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

        public List<Team> Teams { get; set; }

        public int? LocationId { get; set; }

        public Location Location { get; set; }

        public bool IsActive { get; set; }
    }
}
