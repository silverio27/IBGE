using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.Commands;
using Ibge.Domain.Entities;

namespace Ibge.Domain.Repositories
{
    public interface IRegionIbgeRepository
    {
         Task<IEnumerable<RegionCommand>> Get();
    }
}