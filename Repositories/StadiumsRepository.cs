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
                var stadiumExists = _footballDbContext.Stadiums.Any(p => p.Name == addStadiumRequest.Name && p.IsActive);

                if (stadiumExists)
                {
                    return new OperationOutcome { Errors = $"There is already a stadium registered with the name {addStadiumRequest.Name}", IsSuccessful = false };
                }

                var stadium = new Stadium
                {
                    Name = addStadiumRequest.Name,
                    Capacity = addStadiumRequest.Capacity,
                    AddressLine1 = addStadiumRequest.AddressLine1,
                    AddressLine2 = addStadiumRequest.AddressLine2,
                    Suburb = addStadiumRequest.Suburb,
                    Province = addStadiumRequest.Province,
                    PostalCode = addStadiumRequest.PostalCode,
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
                var stadium = _footballDbContext.Find<Stadium>(updateStadiumRequest.Id);

                if (stadium == null)
                {
                    return new OperationOutcome { Errors = $"Could not find record with Id {updateStadiumRequest.Id}", IsSuccessful = false };
                }

                stadium.Name = updateStadiumRequest.Name != null ? updateStadiumRequest.Name : stadium.Name;
                stadium.Capacity = updateStadiumRequest.Capacity != 0 ? updateStadiumRequest.Capacity : stadium.Capacity;
                stadium.AddressLine1 = updateStadiumRequest.AddressLine1 != null ? updateStadiumRequest.AddressLine1 : stadium.AddressLine1;
                stadium.AddressLine2 = updateStadiumRequest.AddressLine2 != null ? updateStadiumRequest.AddressLine2 : stadium.AddressLine2;
                stadium.Suburb = updateStadiumRequest.Suburb != null ? updateStadiumRequest.Suburb : stadium.Suburb;
                stadium.Province = updateStadiumRequest.Province != null ? updateStadiumRequest.Province : stadium.Province;
                stadium.PostalCode = updateStadiumRequest.PostalCode != null ? updateStadiumRequest.PostalCode : stadium.PostalCode;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }

        public QueryOutcome<Stadium> Get(int stadiumId)
        {
            return Do(() =>
            {
                var stadium = _footballDbContext.Find<Stadium>(stadiumId);
                var response = _mapper.Map<Stadium>(stadium);
                return SuccessfulQuery(response);
            });
        }

        public QueryOutcome<IEnumerable<Stadium>> GetAll()
        {
            return Do(() =>
            {
                var stadiums = _footballDbContext.Stadiums;
                var response = _mapper.Map<IEnumerable<Stadium>>(stadiums).OrderBy(x => x.Name).ToList();
                return SuccessfulQuery(response.AsEnumerable());
            });
        }

        public OperationOutcome Deactivate(int stadiumId)
        {
            return Do(() =>
            {
                var team = _footballDbContext.Stadiums.FirstOrDefault(p => p.Id == stadiumId && p.IsActive);

                if (team == null)
                {
                    return new OperationOutcome { Errors = $"Could not find record for stadium with Id {stadiumId}", IsSuccessful = false };
                }

                team.IsActive = false;

                _footballDbContext.SaveChanges();
                return SuccessfulOutcome();
            });
        }
    }
}
