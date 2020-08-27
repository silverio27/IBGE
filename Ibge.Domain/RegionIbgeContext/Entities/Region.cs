using System.ComponentModel.DataAnnotations.Schema;

namespace Ibge.Domain.RegionIbgeContext.Entities
{
    public class Region
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
    }
}