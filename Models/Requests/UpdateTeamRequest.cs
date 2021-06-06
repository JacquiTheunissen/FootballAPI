namespace FootballAPI.Models.Requests
{
    public class UpdateTeamRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manager { get; set; }
    }
}
