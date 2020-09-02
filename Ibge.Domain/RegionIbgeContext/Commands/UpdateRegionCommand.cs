using Ibge.Domain.RegionIbgeContext.Commands.Contracts;

namespace Ibge.Domain.RegionIbgeContext.Commands
{
    public class UpdateRegionCommand : RegionCommand
    {
        public UpdateRegionCommand(int id, string sigla, string nome) : base(id, sigla, nome)
        {
        }
        private UpdateRegionCommand()
        {

        }
    }
}