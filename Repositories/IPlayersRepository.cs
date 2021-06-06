using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;

namespace FootballAPI.Repositories
{
    public interface IPlayersRepository
    {
        OperationOutcome Add(AddPlayerRequest addPlayerRequest);

        OperationOutcome Update(UpdatePlayerRequest updatePlayerRequest);

        QueryOutcome<Player> Get(GetPlayerRequest getPlayerRequest);
    }
}
