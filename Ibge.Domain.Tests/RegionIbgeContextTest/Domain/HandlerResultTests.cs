using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Domain
{       
    public class HandlerResultTests
    {
        [Fact]        
        public void DadoUmResultadoComSucesso()
        {
            var result = new HandlerResult<dynamic>("Tudo certo", new { Valor = 1 });
            Assert.True(result.Success);
        }
        [Fact]
        public void DadoUmResultadoComFalha()
        {
            var result = new HandlerResult<dynamic>("Tudo errado", new { Valor = 1 }, false);
            Assert.False(result.Success);
        }
        [Fact]
        public void DadoUmResultadoComAMensagemTudoCerto()
        {
            var result = new HandlerResult<dynamic>("Tudo certo", new { Valor = 1 }, true);
            Assert.Equal("Tudo certo", result.Message);
        }
        [Fact]
        public void DadoUmResultadoComOValorDoDadoIgualUm()
        {
            var result = new HandlerResult<dynamic>("Tudo certo", new { Valor = 1 }, true);
            Assert.Equal(1, result.Data.Valor);
        }
    }
}