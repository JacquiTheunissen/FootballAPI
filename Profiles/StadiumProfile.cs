using AutoMapper;
using FootballAPI.Models;

namespace FootballAPI.Profiles
{
    public class StadiumProfile : Profile
    {
        public StadiumProfile()
        {
            CreateMap<Stadium, Stadium>().ReverseMap();
        }
    }
}
