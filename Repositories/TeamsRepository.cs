using AutoMapper;
using FootballAPI.Context;
using FootballAPI.Models;
using FootballAPI.Models.Common;
using FootballAPI.Models.Requests;
using Microsoft.Extensions.Logging;
using System;

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
                var teamToEdit = _footballDbContext.Find<Team>(updateTeamRequest.Id);

                if (teamToEdit == null)
                {
                    throw new Exception($"Could not find record with Id {updateTeamRequest.Id}");
                }

                teamToEdit.Name = updateTeamRequest.Name != null ? updateTeamRequest.Name : teamToEdit.Name;
                teamToEdit.Manager = updateTeamRequest.Manager != null ? updateTeamRequest.Manager : teamToEdit.Manager;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<Team> Get(GetTeamRequest getTeamRequest)
        {
            return Do(() =>
            {
                var team = _footballDbContext.Find<Team>(getTeamRequest.Id);
                var response = _mapper.Map<Team>(team);
                return SuccessfulQuery(response);
            });
        }
    }
}
