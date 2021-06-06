namespace FootballAPI.Models.Requests
{
    public class AddPlayerToTeamRequest
    {
        public int PlayerId { get; set; }

        public int TeamId { get; set; }
    }
}
