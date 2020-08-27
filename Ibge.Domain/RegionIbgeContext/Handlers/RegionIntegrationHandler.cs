using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Repositories;

namespace Ibge.Domain.RegionIbgeContext.Handlers
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