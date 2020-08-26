using Microsoft.EntityFrameworkCore;

namespace Ibge.Domain.Tests.Data
{
    public class FakeContext : DbContext
    {
        public FakeContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DataBase");
        }

    }
}