using AutoMapper;
using FootballAPI.Context;
using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
                var playerExists = _footballDbContext.Players.Any(p => p.Name == addPlayerRequest.Name && p.Surname == addPlayerRequest.Surname && p.IsActive);

                if (playerExists)
                {
                    return new OperationOutcome { Errors = $"There is already a player registered with the name {addPlayerRequest.Name} and surname {addPlayerRequest.Surname}", IsSuccessful = false };
                }

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
                var player = _footballDbContext.Find<Player>(updatePlayerRequest.Id);

                if (player == null)
                {
                    return new OperationOutcome { Errors = $"Could not find player with record Id {updatePlayerRequest.Id}", IsSuccessful = false };
                }

                player.Name = updatePlayerRequest.Name != null ? updatePlayerRequest.Name : player.Name;
                player.Surname = updatePlayerRequest.Surname != null ? updatePlayerRequest.Surname : player.Surname;
                player.Height = updatePlayerRequest.Height != 0.00M ? updatePlayerRequest.Height : player.Height;
                player.Weight = updatePlayerRequest.Weight != 0.00M ? updatePlayerRequest.Weight : player.Weight;
                player.Age = updatePlayerRequest.Age != 0 ? updatePlayerRequest.Age : player.Age;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<Player> Get(int playerId)
        {
            return Do(() =>
            {
                var player = _footballDbContext.Find<Player>(playerId);
                var response = _mapper.Map<Player>(player);
                return SuccessfulQuery(response);
            });
        }

        public OperationOutcome AddToTeam(int playerId, int teamId)
        {
            return Do(() =>
            {
                var player = _footballDbContext.Find<Player>(playerId);
                var team = _footballDbContext.Find<Team>(teamId);

                if (player == null)
                {
                    return new OperationOutcome { Errors = $"Could not find player with record Id {playerId}", IsSuccessful = false };
                }

                if (team == null)
                {
                    return new OperationOutcome { Errors = $"Could not find team with record Id {teamId}", IsSuccessful = false };
                }

                if (player.TeamId == teamId)
                {
                    return new OperationOutcome { Errors = "This player is already linked to the selected team.", IsSuccessful = false };
                }

                player.TeamId = teamId;
                _footballDbContext.SaveChanges();

                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<IEnumerable<Player>> GetAll()
        {
            return Do(() =>
            {
                var players = _footballDbContext.Players;
                var response = _mapper.Map<IEnumerable<Player>>(players).OrderBy(x => x.Name).ToList();
                return SuccessfulQuery(response.AsEnumerable());
            });
        }

        public OperationOutcome RemoveFromCurrentTeam(int playerId)
        {
            return Do(() =>
            {
                var player = _footballDbContext.Find<Player>(playerId);

                if (player == null)
                {
                    return new OperationOutcome { Errors = $"Could not find player with record Id {playerId}", IsSuccessful = false };
                }

                if (player.TeamId == null)
                {
                    return new OperationOutcome { Errors = "Player not currently assigned to any teams.", IsSuccessful = false };
                }

                player.TeamId = null;
                _footballDbContext.SaveChanges();

                return SuccessfulOutcome();
            });
        }

        public OperationOutcome Deactivate(int playerId)
        {
            return Do(() =>
            {
                var player = _footballDbContext.Players.FirstOrDefault(p => p.Id == playerId && p.IsActive);

                if (player == null)
                {
                    return new OperationOutcome { Errors = $"Could not find an active player with record Id {playerId}", IsSuccessful = false };
                }

                player.IsActive = false;
                _footballDbContext.SaveChanges();

                return SuccessfulOutcome();
            });
        }
    }
}
