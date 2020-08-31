using Ibge.Domain.RegionIbgeContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ibge.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }
        public DataContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-B88NHP9\SQLEXPRESS2017;Initial Catalog=IBGE;Uid=sa;Pwd=N13tzsche");
        }
        public DbSet<Region> Region { get; set; }
    }
}