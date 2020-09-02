using System.Collections.Generic;
using System.Linq;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.Infra.Contexts;
using Ibge.Domain.RegionIbgeContext.Queries;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ibge.Domain.Infra.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext _context;

        public RegionRepository(DataContext context)
        {
            _context = context;
        }

        public Region Create(Region region)
        {
            _context.Region.Add(region);
            _context.SaveChanges();
            return region;
        }

        public Region Delete(Region region)
        {
             _context.Region.Remove(region);
             _context.SaveChanges();
             return region;
        }

        public bool Exist(Region region)
        {
            return _context.Region.AsNoTracking().Any(RegionQueries.GetRegionById(region.Id));
        }

        public IEnumerable<Region> Get()
        {
            return _context.Region.AsNoTracking().ToList();
        }

        public Region Get(int id)
        {
            return _context.Region
                .FirstOrDefault(RegionQueries.GetRegionById(id));
        }

        public Region Update(Region region)
        {
            _context.Entry(region).State = EntityState.Detached;
            _context.SaveChanges();
            return region;
        }
    }
}