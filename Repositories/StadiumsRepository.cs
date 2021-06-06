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
    public class StadiumsRepository : RepositoryBase, IStadiumsRepository
    {
        private readonly FootballDbContext _footballDbContext;
        private readonly IMapper _mapper;

        public StadiumsRepository(
            ILogger<StadiumsRepository> logger
            , IMapper mapper
            , FootballDbContext footballDbContext
            ) : base(logger)
        {
            _mapper = mapper;
            _footballDbContext = footballDbContext;
        }

        public OperationOutcome Add(AddStadiumRequest addStadiumRequest)
        {
            return Do(() =>
            {
                var stadium = new Stadium
                {
                    Name = addStadiumRequest.Name,
                    Capacity = addStadiumRequest.Capacity,
                    IsActive = true,
                };

                _footballDbContext.Add(stadium);
                _footballDbContext.SaveChanges();

                return SuccessfulOutcome();
            });
        }

        public OperationOutcome Update(UpdateStadiumRequest updateStadiumRequest)
        {
            return Do(() =>
            {
                var stadiumToEdit = _footballDbContext.Find<Stadium>(updateStadiumRequest.Id);

                if (stadiumToEdit == null)
                {
                    throw new Exception($"Could not find record with Id {updateStadiumRequest.Id}");
                }

                stadiumToEdit.Name = updateStadiumRequest.Name != null ? updateStadiumRequest.Name : stadiumToEdit.Name;
                stadiumToEdit.Capacity = updateStadiumRequest.Capacity != 0 ? updateStadiumRequest.Capacity : stadiumToEdit.Capacity;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<Stadium> Get(GetStadiumRequest getStadiumRequest)
        {
            return Do(() =>
            {
                var stadium = _footballDbContext.Find<Stadium>(getStadiumRequest.Id);
                var response = _mapper.Map<Stadium>(stadium);
                return SuccessfulQuery(response);
            });
        }
    }
}
