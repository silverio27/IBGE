using Ibge.Domain.RegionIbgeContext.Commands.Contracts;

namespace Ibge.Domain.RegionIbgeContext.Commands
{
    public class CreateRegionCommand : RegionCommand
    {
        public CreateRegionCommand(int id, string sigla, string nome) : base(id, sigla, nome)
        {
        }
        private CreateRegionCommand()
        {

        }
    }
}