namespace FootballAPI.Models.Common
{
    public class OperationOutcome
    {
        public bool IsSuccessful { get; set; }

        public string Errors { get; set; }
    }
}
