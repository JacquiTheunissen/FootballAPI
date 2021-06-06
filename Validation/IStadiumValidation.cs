using FootballAPI.Models.Requests;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.Validation
{
    public interface IStadiumValidation
    {
        ValidationResult AddStadiumValidation(AddStadiumRequest addStadiumRequest);

        ValidationResult UpdateStadiumValidation(UpdateStadiumRequest updateStadiumRequest);
    }
}
