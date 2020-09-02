using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Enums;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Infra
{
    public class RegionIbgeRepositoryTests
    {

        RegionIbgeRepository _regionIbgeRepository;

        public RegionIbgeRepositoryTests()
        {
            _regionIbgeRepository = new RegionIbgeRepository(new HttpClient());
        }

        [Fact]
        public async Task RequisicaoValida()
        {
            var result = await _regionIbgeRepository.Get(IbgeEndPoints.RegionUrl);
            Assert.True(result.Count() > 0);
        }
        [Fact]
        public async Task RequisicaoInvalida()
        {
            var result = await _regionIbgeRepository.Get(IbgeEndPoints.VoidUrl);
            Assert.False(result.Count() > 0);
        }

    }
}