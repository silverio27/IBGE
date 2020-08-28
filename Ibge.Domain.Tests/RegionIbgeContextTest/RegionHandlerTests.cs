using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.Tests.Data;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest
{
    public class RegionHandlerTests
    {
        private IRegionRepository _repository;
        private RegionCommand validCommand = new RegionCommand(1, "MG", "Minas Gerais");
        private RegionCommand invalidCommand = new RegionCommand(0, "MG", "Minas Gerais");
        private RegionHandler handler;
        public RegionHandlerTests()
        {
            _repository = new RegionRepository(new FakeContext());
            handler = new RegionHandler(_repository);
        }
        [Fact]
        public void DadoUmComandoInválido()
        {
            var result = handler.Handle(invalidCommand);
            Assert.False(result.Success);
        }
        [Fact]
        public void DadoUmComandoInválidoORetornoPedeParaEspecificarMelhorARegiao()
        {
            var result = handler.Handle(invalidCommand);
            Assert.Equal("especifique melhor a região", result.Message);
        }
        [Fact]
        public void DadoUmComandoInválidoPoisARegiaoJaExiste()
        {
            handler.Handle(validCommand);
            var result = handler.Handle(validCommand);
            Assert.Equal("A região já existe", result.Message);
        }
        [Fact]
        public void DadoUmComandoVálido()
        {
            var result = handler.Handle(validCommand);
            Assert.True(result.Success);
        }
    }
}