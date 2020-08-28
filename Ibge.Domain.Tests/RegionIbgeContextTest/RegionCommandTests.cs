using System.Linq;
using Ibge.Domain.RegionIbgeContext.Commands;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest
{
    public class RegionCommandTests
    {
        [Fact]
        public void DadoUmComandoValido()
        {
            var validCommand = new RegionCommand(1, "MG", "Minas Gerais");
            validCommand.Validate();
            Assert.True(validCommand.Valid);
        }

        [Fact]
        public void DadoUmComandoInvalido()
        {
            var invalidCommand = new RegionCommand(0, "", "");
            invalidCommand.Validate();
            Assert.False(invalidCommand.Valid);
        }

        [Fact]
        public void DadoUmComandoInvalidoPelaId(){
            var invalidCommand = new RegionCommand(0,"MG", "Minas Gerais");
            invalidCommand.Validate();
            Assert.Equal("Identidade tem que ser maior que 0.", 
                invalidCommand.Notifications.First().Message);
        }

        [Fact]
        public void DadoUmComandoInvalidoPelaSigla(){
            var invalidCommand = new RegionCommand(1,"", "Minas Gerais");
            invalidCommand.Validate();
            Assert.Equal("A sigla tem que ter pelo menos 1 letra.", 
                invalidCommand.Notifications.First().Message);
        }
        [Fact]
        public void DadoUmComandoInvalidoPeloNome(){
            var invalidCommand = new RegionCommand(1,"MG", "");
            invalidCommand.Validate();
            Assert.Equal("O nome da região precisa ter pelo menos 3 letras.", 
                invalidCommand.Notifications.First().Message);
        }
        
    }
}