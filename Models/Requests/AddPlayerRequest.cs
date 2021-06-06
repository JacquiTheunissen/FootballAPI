namespace FootballAPI.Models.Requests
{
    public class AddPlayerRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public int Age { get; set; }
    }
}
