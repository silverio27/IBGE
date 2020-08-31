using System.Linq;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.Tests.Data;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Infra
{
    public class RepositoryTests
    {
        RegionRepository repository;
        Region regionMg = new Region(10, "MG", "Minas Gerais");
        Region regionRj = new Region(11, "RJ", "Rio de Janeiro");
        Region regionSp = new Region(12, "SP", "São Paulo");
        Region regionSc = new Region(13, "SC", "Santa Cantarina");
        public RepositoryTests()
        {
            repository = new RegionRepository(new FakeContext());

        }

        [Fact]
        public void Create()
        {
            var result = repository.Create(regionMg);
            Assert.Equal(regionMg.Name, result.Name);
        }

        [Fact]
        public void Get()
        {
            var create = repository.Create(regionRj);
            var rjId = create.Id;
            var result = repository.Get(rjId);
            Assert.Equal(create.Id, result.Id);
        }

        [Fact]
        public void Exist()
        {
            var create = repository.Create(regionSp);
            var exist = repository.Exist(regionSp);
            Assert.True(exist);
        }

        [Fact]
        public void GetList()
        {
            var create = repository.Create(regionSc);
            var list = repository.Get();
            Assert.True(list.Count() > 0);
        }

    }
}