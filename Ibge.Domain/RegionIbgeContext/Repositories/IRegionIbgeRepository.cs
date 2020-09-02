using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Enums;

namespace Ibge.Domain.RegionIbgeContext.Repositories
{
    public interface IRegionIbgeRepository
    {
         Task<IEnumerable<CreateRegionCommand>> Get(IbgeEndPoints endPoint);
    }
}