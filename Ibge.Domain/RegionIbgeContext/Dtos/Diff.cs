namespace Ibge.Domain.RegionIbgeContext.Dtos
{

    public class Diff
    {
        public Diff(string local, string ibge)
        {
            Local = local;
            Ibge = ibge;
        }
        public string Local { get; private set; }
        public string Ibge { get; private set; }
    }
}