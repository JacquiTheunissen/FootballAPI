using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using FootballAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public OperationOutcome Get(GetStadiumRequest getStadiumRequest)
        {
            return Do(() => _stadiumsRepository.Get(getStadiumRequest));
        }
    }
}
