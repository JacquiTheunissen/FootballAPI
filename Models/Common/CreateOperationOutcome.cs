using System;

namespace FootballAPI.Models.Common
{
    public class CreateOperationOutcome : OperationOutcome
    {
        public Guid GeneratedIdentifier { get; set; }
    }
}
