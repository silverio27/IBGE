using System;
using System.Collections.Generic;
using Ibge.Domain.Entities;

namespace Ibge.Domain.Repositories
{
    public interface IRegionRepository
    {
         IEnumerable<Region> Get();
         Region Get(int id);
         void Create(Region region);
    }
}