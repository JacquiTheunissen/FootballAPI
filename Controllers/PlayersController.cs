using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using FootballAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet]
        [Route(nameof(Get))]
        public OperationOutcome Get(GetPlayerRequest getPlayerRequest)
        {
            return Do(() => _playersRepository.Get(getPlayerRequest));
        }
    }
}
