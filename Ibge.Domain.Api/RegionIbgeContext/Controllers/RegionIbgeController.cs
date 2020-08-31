using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.Infra.Contexts;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ibge.Domain.Api.RegionIbgeContext.Controllers
{
    [Route("v1/region-ibge")]
    public class RegionIbgeController : Controller
    {
        [HttpGet]
        public IEnumerable<Region> Get(
            [FromServices] IRegionRepository repository)
        {
            return repository.Get();
        }
        // [HttpPost("integration")]
        // public async Task<IEnumerable<HandlerResult<RegionCommand>>> Integration(
        //     [FromServices] RegionIntegrationHandler handler
        // )
        // {
        //     return await handler.Execute();
        // }
    }
}