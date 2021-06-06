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

        [HttpPost]
        [Route(nameof(AddToStadium))]
        public OperationOutcome AddToStadium(int teamId, int stadiumId)
        {
            return Do(() => _teamsRepository.AddToStadium(teamId, stadiumId));
        }

        [HttpGet]
        [Route(nameof(Get))]
        public OperationOutcome Get(int teamId)
        {
            return Do(() => _teamsRepository.Get(teamId));
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public QueryOutcome<IEnumerable<Team>> GetAll()
        {
            return Do(() => _teamsRepository.GetAll());
        }

        [HttpPost]
        [Route(nameof(RemoveFromCurrentStadium))]
        public OperationOutcome RemoveFromCurrentStadium(int teamId)
        {
            return Do(() => _teamsRepository.RemoveFromCurrentStadium(teamId));
        }

        [HttpPost]
        [Route(nameof(Deactivate))]
        public OperationOutcome Deactivate(int teamId)
        {
            return Do(() => _teamsRepository.Deactivate(teamId));
        }
    }
}
