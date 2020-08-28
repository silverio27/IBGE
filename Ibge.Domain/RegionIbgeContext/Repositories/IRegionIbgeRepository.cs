using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Commands;

namespace Ibge.Domain.RegionIbgeContext.Repositories
{
    public interface IRegionIbgeRepository
    {
         Task<IEnumerable<RegionCommand>> Get();
    }
}