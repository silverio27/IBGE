using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Enums;
using Ibge.Domain.RegionIbgeContext.Mapping;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.RegionIbgeContext.ValueObject;

namespace Ibge.Domain.RegionIbgeContext.Services
{
    public class RegionDiffServices : IRegionDiffServices
    {
        private readonly IRegionIbgeRepository _ibgeRepository;
        private readonly IRegionRepository _repository;

        public IEnumerable<RegionDiff> Diffs { get; private set; }
        public IEnumerable<RegionDiff> LocalInexistents { get; private set; }
        public IEnumerable<RegionDiff> IbgeInexistents { get; private set; }
        private RegionDiff regionDiff;


        public RegionDiffServices(
            IRegionIbgeRepository ibgeRepository,
            IRegionRepository repository)
        {
            this._ibgeRepository = ibgeRepository;
            this._repository = repository;
        }
        private RegionDiffServices()
        {
        }
        public async Task<RegionDiffServices> Get()
        {
            var local = _repository.Get();
            var request = await _ibgeRepository.Get(IbgeEndPoints.RegionUrl);
            var ibge = AutoMapperConfiguration.Mapper.Map<List<Region>>(request);
            regionDiff = new RegionDiff(local, ibge);
            this.Diffs = regionDiff.GetDiffs();
            this.IbgeInexistents = regionDiff.GetInexistentsInIbge();
            this.LocalInexistents = regionDiff.GetInexistentsInLocal();
            return this;
        }
    }
}