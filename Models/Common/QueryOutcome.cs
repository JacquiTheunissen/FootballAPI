namespace FootballAPI.Models.Common
{
    public class QueryOutcome<T> : OperationOutcome
    {
        public T Data { get; set; }
    }
}
