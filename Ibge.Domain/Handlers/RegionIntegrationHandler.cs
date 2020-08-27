using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Ibge.Domain.Commands;
using Ibge.Domain.Handlers.Contract;
using Ibge.Domain.Repositories;

namespace Ibge.Domain.Handlers
{
    public class RegionIntegrationHandler : Notifiable, IExecute<RegionCommand>
    {
        IRegionIbgeRepository regionIbgeRepository;
        IHandler<RegionCommand> handler;

        public RegionIntegrationHandler(
            IRegionIbgeRepository regionIbgeRepository,
            IHandler<RegionCommand> handler)
        {
            this.regionIbgeRepository = regionIbgeRepository;
            this.handler = handler;
        }

        public async Task<IEnumerable<HandlerResult<RegionCommand>>> Execute()
        {
            var response = new List<HandlerResult<RegionCommand>>();
            var externalRegions = await regionIbgeRepository.Get();

            if (!externalRegions.Any())
            {
                AddNotification("API IBGE", "A api não retornou dados");
                return response;
            }

            foreach (var item in externalRegions)
            {
                response.Add(handler.Handle(item));
            }
            return response;
        }
    }
}