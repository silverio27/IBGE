using System.Linq;
using System.Threading.Tasks;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Enums;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.Tests.Data;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest
{
    public class RegionIntegrationTests
    {
        IRegionIbgeRepository invalidRegionIbgeRepository;
        IRegionRepository fakeRepository;
        IHandler<RegionCommand> handler;
        RegionIntegrationHandler invalidIntegrationHandler;
        public RegionIntegrationTests()
        {
            invalidRegionIbgeRepository = new RegionIbgeRepository(IbgeEndPoints.VoidUrl);
            fakeRepository = new RegionRepository(new FakeContext());
            handler = new RegionHandler(fakeRepository);
            invalidIntegrationHandler = new RegionIntegrationHandler(invalidRegionIbgeRepository, handler);
        }
        [Fact]
        public async Task ExecucaoMalSucedida()
        {
            var result = await invalidIntegrationHandler.Execute();
            Assert.False(invalidIntegrationHandler.Valid);
        }
    }
}