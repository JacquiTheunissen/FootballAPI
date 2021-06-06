using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manager { get; set; }

        public int? StadiumId { get; set; }

        public Stadium Stadium { get; set; }

        public bool IsActive { get; set; }


        public virtual List<Player> Players { get; set; }
    }
}
