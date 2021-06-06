namespace FootballAPI.Models.Requests
{
    public class UpdateStadiumRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

    }
}
