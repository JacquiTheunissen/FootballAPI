using AutoMapper;
using FootballAPI.Context;
using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballAPI.Repositories
{
    public class TeamsRepository : RepositoryBase, ITeamsRepository
    {
        private readonly FootballDbContext _footballDbContext;
        private readonly IMapper _mapper;

        public TeamsRepository(
            ILogger<TeamsRepository> logger
            , IMapper mapper
            , FootballDbContext footballDbContext
            ) : base(logger)
        {
            _mapper = mapper;
            _footballDbContext = footballDbContext;
        }

        public OperationOutcome Add(AddTeamRequest addTeamRequest)
        {
            return Do(() =>
            {
                var teamExists = _footballDbContext.Teams.Any(p => p.Name == addTeamRequest.Name && p.IsActive);

                if (teamExists)
                {
                    return new OperationOutcome { Errors = $"There is already a team registered with the name {addTeamRequest.Name}", IsSuccessful = false };
                }

                var team = new Team
                {
                    Name = addTeamRequest.Name,
                    Manager = addTeamRequest.Manager,
                    IsActive = true,
                };

                _footballDbContext.Add(team);
                _footballDbContext.SaveChanges();

                return SuccessfulOutcome();
            });
        }

        public OperationOutcome Update(UpdateTeamRequest updateTeamRequest)
        {
            return Do(() =>
            {
                var team = _footballDbContext.Find<Team>(updateTeamRequest.Id);

                if (team == null)
                {
                    return new OperationOutcome { Errors = $"Could not find record for team with Id {updateTeamRequest.Id}", IsSuccessful = false };
                }

                team.Name = updateTeamRequest.Name != null ? updateTeamRequest.Name : team.Name;
                team.Manager = updateTeamRequest.Manager != null ? updateTeamRequest.Manager : team.Manager;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<Team> Get(int teamId)
        {
            return Do(() =>
            {
                var team = _footballDbContext.Find<Team>(teamId);
                var response = _mapper.Map<Team>(team);
                return SuccessfulQuery(response);
            });
        }

        public OperationOutcome AddToStadium(int teamId, int stadiumId)
        {
            return Do(() =>
            {
                var team = _footballDbContext.Find<Team>(teamId);
                var stadium = _footballDbContext.Find<Stadium>(stadiumId);

                if (team == null)
                {
                    return new OperationOutcome { Errors = $"Could not find record for team with Id {teamId}", IsSuccessful = false };
                }

                if (stadium == null)
                {
                    return new OperationOutcome { Errors = $"Could not find record for stadium with Id {stadium}", IsSuccessful = false };
                }

                team.StadiumId = stadiumId != 0 ? stadiumId : team.StadiumId;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<IEnumerable<Team>> GetAll()
        {
            return Do(() =>
            {
                var teams = _footballDbContext.Teams;
                var response = _mapper.Map<IEnumerable<Team>>(teams).OrderBy(x => x.Name).ToList();
                return SuccessfulQuery(response.AsEnumerable());
            });
        }

        public OperationOutcome RemoveFromCurrentStadium(int teamId)
        {
            return Do(() =>
            {
                var team = _footballDbContext.Find<Team>(teamId);

                if (team == null)
                {
                    return new OperationOutcome { Errors = $"Could not find record for team with Id {teamId}", IsSuccessful = false };
                }

                if (team.StadiumId == null)
                {
                    return new OperationOutcome { Errors = "Team not currently assigned to a stadium.", IsSuccessful = false };
                }

                team.StadiumId = null;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public OperationOutcome Deactivate(int teamId)
        {
            return Do(() =>
            {
                var team = _footballDbContext.Teams.FirstOrDefault(p => p.Id == teamId && p.IsActive);

                if (team == null)
                {
                    return new OperationOutcome { Errors = $"Could not find record for team with Id {teamId}", IsSuccessful = false };
                }

                team.IsActive = false;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }
    }
}
