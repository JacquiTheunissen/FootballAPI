using AutoMapper;
using FootballAPI.Context;
using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Repositories
{
    public class PlayersRepository : RepositoryBase, IPlayersRepository
    {
        private readonly FootballDbContext _footballDbContext;
        private readonly IMapper _mapper;

        public PlayersRepository(
            ILogger<PlayersRepository> logger
            , IMapper mapper
            , FootballDbContext footballDbContext
            ) : base(logger)
        {
            _mapper = mapper;
            _footballDbContext = footballDbContext;
        }

        public OperationOutcome Add(AddPlayerRequest addPlayerRequest)
        {
            return Do(() =>
            {
                var player = new Player
                {
                    Name = addPlayerRequest.Name,
                    Surname = addPlayerRequest.Surname,
                    Height = addPlayerRequest.Height,
                    Weight = addPlayerRequest.Weight,
                    Age = addPlayerRequest.Age,
                    IsActive = true,
                };

                _footballDbContext.Add(player);
                _footballDbContext.SaveChanges();

                return SuccessfulOutcome();
            });
        }

        public OperationOutcome Update(UpdatePlayerRequest updatePlayerRequest)
        {
            return Do(() =>
            {
                var playerToEdit = _footballDbContext.Find<Player>(updatePlayerRequest.Id);

                if (playerToEdit == null)
                {
                    throw new Exception($"Could not find record with Id {updatePlayerRequest.Id}");
                }

                playerToEdit.Name = updatePlayerRequest.Name != null ? updatePlayerRequest.Name : playerToEdit.Name;
                playerToEdit.Surname = updatePlayerRequest.Surname != null ? updatePlayerRequest.Surname : playerToEdit.Surname;
                playerToEdit.Height = updatePlayerRequest.Height != 0.00M ? updatePlayerRequest.Height : playerToEdit.Height;
                playerToEdit.Weight = updatePlayerRequest.Weight != 0.00M ? updatePlayerRequest.Weight : playerToEdit.Weight;
                playerToEdit.Age = updatePlayerRequest.Age != 0 ? updatePlayerRequest.Age : playerToEdit.Age;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<Player> Get(GetPlayerRequest getPlayerRequest)
        {
            return Do(() =>
            {
                var player = _footballDbContext.Find<Player>(getPlayerRequest.Id);
                var response = _mapper.Map<Player>(player);
                return SuccessfulQuery(response);
            });
        }
    }
}
