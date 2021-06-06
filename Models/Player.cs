using System.ComponentModel.DataAnnotations;

namespace FootballAPI.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public int Age { get; set; }

        public int? TeamId { get; set; }

        public Team Team { get; set; }

        public bool IsActive { get; set; }
    }
}
