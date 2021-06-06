using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using System.Collections.Generic;

namespace FootballAPI.Repositories
{
    public interface ITeamsRepository
    {
        OperationOutcome Add(AddTeamRequest addTeamRequest);

        OperationOutcome Update(UpdateTeamRequest updateTeamRequest);

        OperationOutcome AddToStadium(int teamId, int stadiumId);

        QueryOutcome<Team> Get(int teamId);

        QueryOutcome<IEnumerable<Team>> GetAll();

        OperationOutcome RemoveFromCurrentStadium(int teamId);

        OperationOutcome Deactivate(int teamId);
    }
}
