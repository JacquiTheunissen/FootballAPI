using FootballAPI.Context;
using FootballAPI.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Validation
{
    public class StadiumValidation : IStadiumValidation
    {
        private readonly FootballDbContext _footballDbContext;

        public StadiumValidation(FootballDbContext footballDbContext)
        {
            _footballDbContext = footballDbContext;
        }

        public ValidationResult AddStadiumValidation(AddStadiumRequest addStadiumRequest)
        {
            if (StadiumAlreadyExists(addStadiumRequest.Name))
            {
                return new ValidationResult($"There is already a stadium registered with the name {addStadiumRequest.Name}");
            }

            return null;
        }

        public ValidationResult UpdateStadiumValidation(UpdateStadiumRequest updateStadiumRequest)
        {
            if (StadiumAlreadyExists(updateStadiumRequest.Name))
            {
                return new ValidationResult($"There is already a stadium registered with the name {updateStadiumRequest.Name}");
            }

            return null;
        }

        private bool StadiumAlreadyExists(string name)
        {
            return _footballDbContext.Stadiums.Any(p => p.Name == name && p.IsActive);
        }
    }
}
