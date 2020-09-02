using Ibge.Domain.RegionIbgeContext.Commands.Contracts;

namespace Ibge.Domain.RegionIbgeContext.Commands
{
    public class DeleteRegionCommand : RegionCommand
    {
        public DeleteRegionCommand(int id, string sigla, string nome) : base(id, sigla, nome)
        {
        }
    }
}