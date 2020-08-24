using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.Entities;

namespace Ibge.Domain.Repositories
{
    public interface IRegionIbgeRepository
    {
         Task<IEnumerable<Region>> Get();
    }
}