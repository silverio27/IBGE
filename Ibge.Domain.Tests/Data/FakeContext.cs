using Ibge.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ibge.Domain.Tests.Data
{
    public class FakeContext : DataContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DataBase");
        }

    }
}