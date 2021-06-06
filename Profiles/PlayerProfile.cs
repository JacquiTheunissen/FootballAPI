using AutoMapper;
using FootballAPI.Models;

namespace FootballAPI.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, Player>().ReverseMap();
        }
    }
}
