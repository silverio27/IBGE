using Ibge.Domain.RegionIbgeContext.Entities;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest
{
    public class RegionEntitieTests
    {
        [Fact]
        public void DadoUmaRegiaoValidaComIdIgualUm()
        {
            var region = new Region(1, "MG", "Minas Gerais");
            Assert.Equal(1, region.Id);
        }

        [Fact]
        public void DadoUmaRegiaoValidaComASiglaIgualAMg()
        {
            var region = new Region(1, "MG", "Minas Gerais");
            Assert.Equal("MG", region.Initials);
        }
        [Fact]
        public void DadoUmaRegiaoValidaComONomeIgualAMinasGerais()
        {
            var region = new Region(1, "MG", "Minas Gerais");
            Assert.Equal("Minas Gerais", region.Name);
        }

    }
}