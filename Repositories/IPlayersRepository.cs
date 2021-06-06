using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using System.Collections.Generic;

namespace FootballAPI.Repositories
{
    public interface IPlayersRepository
    {
        OperationOutcome Add(AddPlayerRequest addPlayerRequest);

        OperationOutcome Update(UpdatePlayerRequest updatePlayerRequest);

        QueryOutcome<Player> Get(int playerId);

        OperationOutcome AddToTeam(AddPlayerToTeamRequest addPlayerToTeamRequest);

        QueryOutcome<IEnumerable<Player>> GetAll();

        OperationOutcome RemoveFromCurrentTeam(int playerId);

        OperationOutcome Deactivate(int playerId);
    }
}
