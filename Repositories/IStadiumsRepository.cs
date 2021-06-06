using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;

namespace FootballAPI.Repositories
{
    public interface IStadiumsRepository
    {
        OperationOutcome Add(AddStadiumRequest addStadiumRequest);

        OperationOutcome Update(UpdateStadiumRequest updateStadiumRequest);

        QueryOutcome<Stadium> Get(GetStadiumRequest getStadiumRequest);
    }
}
