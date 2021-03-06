using System;
using System.Linq.Expressions;
using Ibge.Domain.RegionIbgeContext.Entities;

namespace Ibge.Domain.RegionIbgeContext.Queries
{
    public static class RegionQueries
    {
        public static Expression<Func<Region, bool>> GetRegionById(int id)
        {
            return x => x.Id == id;
        }
    }
}