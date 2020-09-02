using System.Collections.Generic;
using Ibge.Domain.RegionIbgeContext.Entities;

namespace Ibge.Domain.RegionIbgeContext.Repositories
{
    public interface IRegionRepository
    {
        IEnumerable<Region> Get();
        Region Get(int id);
        Region Create(Region region);
        Region Update(Region region);
        Region Delete(Region region);
        bool Exist(Region region);
    }
}