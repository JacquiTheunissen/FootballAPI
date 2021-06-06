namespace FootballAPI.Models.Requests
{
    public class UpdateStadiumRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Suburb { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

    }
}
