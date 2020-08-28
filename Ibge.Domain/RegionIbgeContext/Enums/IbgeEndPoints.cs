namespace Ibge.Domain.RegionIbgeContext.Enums
{
    public class IbgeEndPoints
    {
        private IbgeEndPoints(string value) { Value = value; }
        public string Value { get; private set; }
        public static IbgeEndPoints RegionUrl
        {
            get
            {
                return new IbgeEndPoints("https://servicodados.ibge.gov.br/api/v1/localidades/regioes");
            }
        }
        public static IbgeEndPoints VoidUrl
        {
            get
            {
                return new IbgeEndPoints("");
            }
        }
    }
}