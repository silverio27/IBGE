using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Enums;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.Tests.Data;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Domain
{
    public class RegionIntegrationTests
    {
        IRegionIbgeRepository invalidRegionIbgeRepository;
        IRegionIbgeRepository validRegionIbgeRepository;
        IRegionRepository fakeRepository;
        IHandler<CreateRegionCommand> handler;
        RegionIntegrationHandler invalidIntegrationHandler;
        RegionIntegrationHandler validIntegrationHandler;
        HttpClient _http;
        public RegionIntegrationTests()
        {
            fakeRepository = new RegionRepository(new FakeContext());
            handler = new RegionHandler(fakeRepository);
            _http = new HttpClient();
            
            invalidRegionIbgeRepository = new RegionIbgeRepository(null);
            invalidIntegrationHandler = new RegionIntegrationHandler(invalidRegionIbgeRepository, handler);
            
            validRegionIbgeRepository = new RegionIbgeRepository(_http);
            validIntegrationHandler = new RegionIntegrationHandler(validRegionIbgeRepository, handler);
        }

        [Fact]
        public async Task ExecucaoInvalida()
        {
            var result = await invalidIntegrationHandler.Execute();
            Assert.False(result.Count() > 0);
        }

        [Fact]
        public async Task ExecucaoInvalidaMensagem()
        {
            var result = await invalidIntegrationHandler.Execute();
            Assert.Equal("A api não retornou dados",
                invalidIntegrationHandler.Notifications.First().Message);
        }

        [Fact]
        public async Task ExecucaoValida()
        {
            var result = await validIntegrationHandler.Execute();
            Assert.True(result.Count() > 0);
        }

    }
}