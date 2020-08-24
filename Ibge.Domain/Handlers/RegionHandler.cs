using System;
using System.Collections.Generic;
using System.Linq;
using Ibge.Domain.Entities;
using Ibge.Domain.Handlers.Contract;
using Ibge.Domain.Repositories;

namespace Ibge.Domain.Handlers
{
    public class RegionHandler : IHandler<Region>
    {

        IRegionRepository _repository;

        public RegionHandler(IRegionRepository repository)
        {
            _repository = repository;
        }

        public IGenericResult Handle(Region command)
        {
            try
            {

                _repository.Create(command);
                return new SuccessResult<Region>($"{command.Name} incluída.", command);
            }
            catch (Exception e)
            {
                return new FailResult($"{command.Name} não pode ser incluída.", e);
            }
        }

        public IGenericResult Handle(IEnumerable<Region> command)
        {
            try
            {
                foreach (var item in command)
                    _repository.Create(item);

                return new SuccessResult<IEnumerable<Region>>($"A lista de regiões foi incluída.", command);
            }
            catch (Exception e)
            {
                return new FailResult($"A lista de regiões não pode ser incluída.", e);
            }
        }
    }
}