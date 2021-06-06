using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using FootballAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FootballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : FootballBaseController
    {
        private readonly IPlayersRepository _playersRepository;

        public PlayersController(ILogger<PlayersController> logger,
            IPlayersRepository playersRepository) : base(logger)
        {
            _playersRepository = playersRepository;
        }

        [HttpPost]
        [Route(nameof(Add))]
        public OperationOutcome Add(AddPlayerRequest addPlayerRequest)
        {
            return Do(() => _playersRepository.Add(addPlayerRequest));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public OperationOutcome Update(UpdatePlayerRequest updatePlayerRequest)
        {
            return Do(() => _playersRepository.Update(updatePlayerRequest));
        }

        [HttpPost]
        [Route(nameof(AddToTeam))]
        public OperationOutcome AddToTeam(AddPlayerToTeamRequest addPlayerToTeamRequest)
        {
            return Do(() => _playersRepository.AddToTeam(addPlayerToTeamRequest));
        }

        [HttpGet]
        [Route(nameof(Get))]
        public OperationOutcome Get(int playerId)
        {
            return Do(() => _playersRepository.Get(playerId));
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public QueryOutcome<IEnumerable<Player>> GetAll()
        {
            return Do(() => _playersRepository.GetAll());
        }

        [HttpPost]
        [Route(nameof(RemoveFromCurrentTeam))]
        public OperationOutcome RemoveFromCurrentTeam(int playerId)
        {
            return Do(() => _playersRepository.RemoveFromCurrentTeam(playerId));
        }

        [HttpPost]
        [Route(nameof(Deactivate))]
        public OperationOutcome Deactivate(int playerId)
        {
            return Do(() => _playersRepository.Deactivate(playerId));
        }
    }
}
