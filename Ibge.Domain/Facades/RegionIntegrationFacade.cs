using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.Entities;
using Ibge.Domain.Handlers.Contract;
using Ibge.Domain.Repositories;

namespace Ibge.Domain.Facades
{
    public class RegionIntegrationFacade
    {
        private IRegionIbgeRepository _externalRepository;
        private IRegionRepository _repository;

        public RegionIntegrationFacade(
            IRegionIbgeRepository externalRepository,
            IRegionRepository repository)
        {
            _externalRepository = externalRepository;
            _repository = repository;
        }

        public async Task<IGenericResult> Execute()
        {
            try
            {
                var externalRegions = await _externalRepository.Get();

                foreach (var item in externalRegions)
                    _repository.Create(item);

                return new SuccessResult<IEnumerable<Region>>("Regiões incluídas", externalRegions);
            }
            catch (Exception e)
            {

                return new FailResult( "Não foi possível incluir as regiões", e);
            }
        }
    }
}