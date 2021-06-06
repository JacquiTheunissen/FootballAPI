using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using System.Collections.Generic;

namespace FootballAPI.Repositories
{
    public interface IStadiumsRepository
    {
        OperationOutcome Add(AddStadiumRequest addStadiumRequest);

        OperationOutcome Update(UpdateStadiumRequest updateStadiumRequest);

        QueryOutcome<Stadium> Get(int stadiumId);

        QueryOutcome<IEnumerable<Stadium>> GetAll();

        OperationOutcome Deactivate(int stadiumId);
    }
}
