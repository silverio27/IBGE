using System.Collections.Generic;
using System.Linq;
using Ibge.Domain.Entities;
using Ibge.Domain.Infra.Contexts;
using Ibge.Domain.Queries;
using Ibge.Domain.Repositories;

namespace Ibge.Domain.Infra.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DataContext _context;

        public RegionRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Region region)
        {
            _context.Region.Add(region);
            _context.SaveChanges();
        }

        public IEnumerable<Region> Get()
        {
            return _context.Region.ToList();
        }

        public Region Get(int id)
        {
            return _context.Region
                .FirstOrDefault(RegionQueries.GetRegionById(id));
        }
    }
}