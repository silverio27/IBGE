using Ibge.Domain.RegionIbgeContext.Enums;
using Xunit;

namespace Ibge.Domain.Tests.RegionIbgeContextTest.Domain
{
    public class RegionEnumTests
    {
        [Fact]
        public void EndPointDeRegiaoValido()
        {
            Assert.Equal("https://servicodados.ibge.gov.br/api/v1/localidades/regioes",
            IbgeEndPoints.RegionUrl.Value);
        }

        [Fact]
        public void EndPointVoidValid()
        {
            Assert.Equal("",IbgeEndPoints.VoidUrl.Value);
        }

    }
}