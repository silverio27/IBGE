using System.Linq;
using System.Collections.Generic;
using Ibge.Domain.RegionIbgeContext.Entities;
using System;
using Ibge.Domain.RegionIbgeContext.Dtos;

namespace Ibge.Domain.RegionIbgeContext.ValueObject
{
    public partial class RegionDiff
    {
        private IEnumerable<Region> _local;
        private IEnumerable<Region> _ibge;
        public int Id { get; private set; }
        public Diff Initials { get; private set; }
        public Diff Name { get; private set; }
        public bool isDiferent { get; private set; }
        public RegionDiff(IEnumerable<Region> local, IEnumerable<Region> ibge)
        {
            _local = local;
            _ibge = ibge;
        }

        private RegionDiff()
        {

        }
        public IEnumerable<RegionDiff> GetDiffs()
        {
            return (from l in _local
                    join i in _ibge on l.Id equals i.Id
                    select new RegionDiff()
                    {
                        Id = l.Id,
                        Initials = new Diff(l.Initials, i.Initials),
                        Name = new Diff(l.Name, i.Name),
                        isDiferent = !l.Equals(i),
                    }).Where(x => x.isDiferent);
        }
        public IEnumerable<Region> GetNonexistentsInIbge()
        {
            return from l in _local
                   where !(_ibge.Any(i => i.Id == l.Id))
                   select l;
        }
        public IEnumerable<Region> GetNonexistentInLocal()
        {
            return from l in _ibge
                   where !(_local.Any(i => i.Id == l.Id))
                   select l;
        }
    }
}