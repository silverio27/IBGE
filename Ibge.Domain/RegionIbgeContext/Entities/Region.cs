using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Ibge.Domain.RegionIbgeContext.Entities
{
    public class Region : IEquatable<Region>
    {
        public Region(int id, string initials, string name)
        {
            Id = id;
            Initials = initials;
            Name = name;
        }
        private Region()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; private set; }
        public string Initials { get; private set; }
        public string Name { get; private set; }

        public bool Equals(Region other)
        {
            return this.Name == other.Name &&
                   this.Initials == other.Initials;
        }
    }
}