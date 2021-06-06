using AutoMapper;
using FootballAPI.Models;

namespace FootballAPI.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, Team>().ReverseMap();
        }
    }
}
