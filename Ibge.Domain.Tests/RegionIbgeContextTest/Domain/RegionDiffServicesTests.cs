using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.RegionIbgeContext.Services;
using Ibge.Domain.Tests.Data;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Domain
{
    public class RegionDiffServicesTests
    {
        HttpClient httpClient;
        IRegionIbgeRepository regionIbgeRepository;
        FakeContext context;
        IRegionRepository regionRepository;
        List<Region> local;
        IRegionDiffServices regionDiffServices;
        public RegionDiffServicesTests()
        {
            httpClient = new HttpClient();
            regionIbgeRepository = new RegionIbgeRepository(httpClient);
            context = new FakeContext();
            regionRepository = new RegionRepository(context);
            context.Region.RemoveRange(regionRepository.Get());
            local = new List<Region>(){
                new Region(1, "N", "Norte"),
                new Region(2, "NE", "Nordeste"),
                new Region(3, "SE", "Sudeste"),
                new Region(4, "S", "Sul"),
                new Region(5, "CO", "Centro-Oeste")
            };
            local.ForEach(x => regionRepository.Create(x));


            regionDiffServices = new RegionDiffServices(regionIbgeRepository, regionRepository);

        }
        [Fact]
        public async Task NoDiffs()
        {
            var result = await regionDiffServices.Get();
            Assert.Empty(result.Diffs);
        }
        [Fact]
        public async Task NoLocalNonexistent()
        {
            var result = await regionDiffServices.Get();
            Assert.Empty(result.LocalNonexistent);
        }
        [Fact]
        public async Task NoIbgeNonexistent()
        {
            var result = await regionDiffServices.Get();
            Assert.Empty(result.IbgeNonexistent);
        }
        [Fact]
        public async Task ComUmaDiferenca()
        {
            var first = regionRepository.Get(1);
            regionRepository.Delete(first);
            regionRepository.Create(new Region(1, "V", "Vorte"));
            var result = await regionDiffServices.Get();
            Assert.NotEmpty(result.Diffs);
        }
        [Fact]
        public async Task ComUmaItemFaltanteEmLocal()
        {
            var first = regionRepository.Get(1);
            regionRepository.Delete(first);
            var result = await regionDiffServices.Get();
            Assert.NotEmpty(result.LocalNonexistent);
        }

    }
}