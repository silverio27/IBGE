using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.ValueObject;

namespace Ibge.Domain.RegionIbgeContext.Services
{
    public interface IRegionDiffServices
    {
        IEnumerable<RegionDiff> Diffs { get; }
        IEnumerable<RegionDiff> LocalInexistents { get; }
        IEnumerable<RegionDiff> IbgeInexistents { get; }

        Task<RegionDiffServices> Get();
    }
}