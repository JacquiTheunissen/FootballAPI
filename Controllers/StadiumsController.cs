using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using FootballAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FootballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : FootballBaseController
    {
        private readonly IStadiumsRepository _stadiumsRepository;

        public StadiumsController(ILogger<StadiumsController> logger,
            IStadiumsRepository stadiumsRepository) : base(logger)
        {
            _stadiumsRepository = stadiumsRepository;
        }

        [HttpPost]
        [Route(nameof(Add))]
        public OperationOutcome Add(AddStadiumRequest addStadiumRequest)
        {
            return Do(() => _stadiumsRepository.Add(addStadiumRequest));
        }

        [HttpPost]
        [Route(nameof(Update))]
        public OperationOutcome Update(UpdateStadiumRequest updateStadiumRequest)
        {
            return Do(() => _stadiumsRepository.Update(updateStadiumRequest));
        }

        [HttpGet]
        [Route(nameof(Get))]
        public QueryOutcome<Stadium> Get(int stadiumId)
        {
            return Do(() => _stadiumsRepository.Get(stadiumId));
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public QueryOutcome<IEnumerable<Stadium>> GetAll()
        {
            return Do(() => _stadiumsRepository.GetAll());
        }

        [HttpPost]
        [Route(nameof(Deactivate))]
        public OperationOutcome Deactivate(int stadiumId)
        {
            return Do(() => _stadiumsRepository.Deactivate(stadiumId));
        }
    }
}
