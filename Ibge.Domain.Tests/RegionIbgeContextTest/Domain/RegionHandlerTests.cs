using System;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.Tests.Data;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Domain
{
    public class RegionHandlerTests
    {
        private IRegionRepository _repository;
        private RegionCommand firstValidCommand = new RegionCommand(3, "SP", "São Paulo");
         private RegionCommand secondValidCommand = new RegionCommand(4, "RJ", "Rio de Janeiro");
        private RegionCommand invalidCommand = new RegionCommand(0, "RJ", "Rio de Janeiro");
        private RegionHandler handlerValid;

        public RegionHandlerTests()
        {
            _repository = new RegionRepository(new FakeContext());
            handlerValid = new RegionHandler(_repository);
        }
        [Fact]
        public void DadoUmComandoValido()
        {
            var result = handlerValid.Handle(firstValidCommand);
            Assert.True(result.Success);
        }
        [Fact]
        public void DadoUmComandoInválido()
        {
            var result = handlerValid.Handle(invalidCommand);
            Assert.False(result.Success);
        }
        [Fact]
        public void DadoUmComandoInválidoORetornoPedeParaEspecificarMelhorARegiao()
        {
            var result = handlerValid.Handle(invalidCommand);
            Assert.Equal("especifique melhor a região", result.Message);
        }
        [Fact]
        public void DadoUmComandoInválidoPoisARegiaoJaExiste()
        {
            var result = handlerValid.Handle(firstValidCommand);
            Assert.Equal("A região já existe", result.Message);
        }

    }
}