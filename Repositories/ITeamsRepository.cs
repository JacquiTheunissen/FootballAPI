using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;

namespace FootballAPI.Repositories
{
    public interface ITeamsRepository
    {
        OperationOutcome Add(AddTeamRequest addTeamRequest);

        OperationOutcome Update(UpdateTeamRequest updateTeamRequest);

        QueryOutcome<Team> Get(GetTeamRequest getTeamRequest);
    }
}
