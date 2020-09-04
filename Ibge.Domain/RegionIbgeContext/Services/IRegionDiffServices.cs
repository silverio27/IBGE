using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.ValueObject;

namespace Ibge.Domain.RegionIbgeContext.Services
{
    public interface IRegionDiffServices
    {
        IEnumerable<RegionDiff> Diffs { get; }
        IEnumerable<Region> LocalNonexistent { get; }
        IEnumerable<Region> IbgeNonexistent { get; }

        Task<RegionDiffServices> Get();
    }
}