using System.Collections.Generic;
using Ibge.Domain.RegionIbgeContext.Entities;

namespace Ibge.Domain.RegionIbgeContext.Repositories
{
    public interface IRegionRepository
    {
         IEnumerable<Region> Get();
         Region Get(int id);
         void Create(Region region);
         bool Exist(Region region);
    }
}