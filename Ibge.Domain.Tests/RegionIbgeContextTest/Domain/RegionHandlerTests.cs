using System;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.Tests.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Domain
{
    public class RegionHandlerTests
    {
        private IRegionRepository _repository;
        private CreateRegionCommand firstValidCommand = new CreateRegionCommand(3, "SP", "São Paulo");
        private CreateRegionCommand secondValidCommand = new CreateRegionCommand(4, "RJ", "Rio de Janeiro");
        private CreateRegionCommand invalidCommand = new CreateRegionCommand(0, "RJ", "Rio de Janeiro");
        private UpdateRegionCommand updateValidCommand = new UpdateRegionCommand(4, "RJ", "Rio de Janeiro");
        private UpdateRegionCommand updateInvalidCommand = new UpdateRegionCommand(0, "RJ", "Rio de Janeiro");
        private UpdateRegionCommand updateInexistCommand = new UpdateRegionCommand(100, "RJ", "Rio de Janeiro");
        private DeleteRegionCommand deleteValidCommand = new DeleteRegionCommand(4, "RJ", "Rio de Janeiro");
        private DeleteRegionCommand deleteInvalidCommand = new DeleteRegionCommand(0, "RJ", "Rio de Janeiro");
        private DeleteRegionCommand deleteInexistCommand = new DeleteRegionCommand(100, "RJ", "Rio de Janeiro");
        private RegionHandler handlerValid;

        public RegionHandlerTests()
        {
            var context = new FakeContext();
            _repository = new RegionRepository(context);
            context.RemoveRange(_repository.Get());
            handlerValid = new RegionHandler(_repository);
            handlerValid.Handle(secondValidCommand);
        }
        [Fact]
        public void DadoUmComandoValidoParaCriacao()
        {
            var result = handlerValid.Handle(firstValidCommand);
            Assert.True(result.Success);
        }
        [Fact]
        public void DadoUmComandoValidoParaAtualizacao()
        {
            var result = handlerValid.Handle(updateValidCommand);
            Assert.True(result.Success);
        }
        [Fact]
        public void DadoUmComandoValidoParaDelecao()
        {
            var result = handlerValid.Handle(deleteValidCommand);
            Assert.True(result.Success);
        }
        [Fact]
        public void DadoUmComandoInválidoParaCriacao()
        {
            var result = handlerValid.Handle(invalidCommand);
            Assert.False(result.Success);
        }
        [Fact]
        public void DadoUmComandoInválidoParaAtualizacao()
        {
            var result = handlerValid.Handle(updateInvalidCommand);
            Assert.False(result.Success);
        }
        [Fact]
        public void DadoUmComandoInválidoParaDelecao()
        {
            var result = handlerValid.Handle(deleteInvalidCommand);
            Assert.False(result.Success);
        }
        [Fact]
        public void DadoUmComandoInválidoORetornoPedeParaEspecificarMelhorARegiaoParaCriacao()
        {
            var result = handlerValid.Handle(invalidCommand);
            Assert.Equal("especifique melhor a região", result.Message);
        }
        [Fact]
        public void DadoUmComandoInválidoORetornoPedeParaEspecificarMelhorARegiaoParaAtualizacao()
        {
            var result = handlerValid.Handle(updateInvalidCommand);
            Assert.Equal("especifique melhor a região", result.Message);
        }
        [Fact]
        public void DadoUmComandoInválidoPoisARegiaoNaoExisteParaAtualizacao()
        {
            var result = handlerValid.Handle(updateInexistCommand);
            Assert.Equal("A região não existe", result.Message);
        }
        [Fact]
        public void DadoUmComandoInválidoPoisARegiaoNaoExisteParaDelecao()
        {
            var result = handlerValid.Handle(deleteInexistCommand);
            Assert.Equal("A região não existe", result.Message);
        }
        [Fact]
        public void DadoUmComandoInválidoPoisARegiaoJaExiste()
        {
            var result = handlerValid.Handle(firstValidCommand);
            Assert.Equal("A região já existe", result.Message);
        }

    }
}