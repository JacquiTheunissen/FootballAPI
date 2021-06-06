namespace FootballAPI.Models.Requests
{
    public class UpdatePlayerRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public int Age { get; set; }
    }
}
