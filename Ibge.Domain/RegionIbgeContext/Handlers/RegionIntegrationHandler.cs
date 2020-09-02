using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Enums;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Repositories;

namespace Ibge.Domain.RegionIbgeContext.Handlers
{
    public class RegionIntegrationHandler : Notifiable, IExecute<CreateRegionCommand>
    {
        IRegionIbgeRepository regionIbgeRepository;
        IHandler<CreateRegionCommand> handler;

        public RegionIntegrationHandler(
            IRegionIbgeRepository regionIbgeRepository,
            IHandler<CreateRegionCommand> handler)
        {
            this.regionIbgeRepository = regionIbgeRepository;
            this.handler = handler;
        }

        public async Task<IEnumerable<HandlerResult<CreateRegionCommand>>> Execute()
        {
            var response = new List<HandlerResult<CreateRegionCommand>>();
            var externalRegions = await regionIbgeRepository.Get(IbgeEndPoints.RegionUrl);

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