using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using FootballAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FootballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : FootballBaseController
    {
        private readonly ITeamsRepository _teamsRepository;

        public TeamsController(ILogger<TeamsController> logger,
            ITeamsRepository teamsRepository) : base(logger)
        {
            _teamsRepository = teamsRepository;
        }

        [HttpPost]
        [Route(nameof(Add))]
        public OperationOutcome Add(AddTeamRequest addTeamRequest)
        {
            return Do(() => _teamsRepository.Add(addTeamRequest));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public OperationOutcome Update(UpdateTeamRequest updateTeamRequest)
        {
            return Do(() => _teamsRepository.Update(updateTeamRequest));
        }

        [HttpGet]
        [Route(nameof(Get))]
        public OperationOutcome Get(GetTeamRequest getTeamRequest)
        {
            return Do(() => _teamsRepository.Get(getTeamRequest));
        }
    }
}
