using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Enums;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Mapping;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Ibge.Domain.RegionIbgeContext.Services;
using Ibge.Domain.RegionIbgeContext.ValueObject;
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
        [HttpGet("{id:int}")]
        public Region GetById(
            [FromServices] IRegionRepository repository,
            int id)
        {
            return repository.Get(id);
        }
        [HttpGet("diff")]
        public async Task<RegionDiffServices> GetDiff(
            [FromServices] IRegionDiffServices services)
        {
            return await services.Get();
        }
        [HttpPost]
        public HandlerResult<CreateRegionCommand> Post(
            [FromServices] IHandler<CreateRegionCommand> handler,
            [FromBody] CreateRegionCommand command)
        {
            return handler.Handle(command);
        }
        [HttpPost("integration")]
        public async Task<IEnumerable<HandlerResult<CreateRegionCommand>>> Integration(
            [FromServices] RegionIntegrationHandler handler)
        {
            return await handler.Execute();
        }
        [HttpPut]
        public HandlerResult<UpdateRegionCommand> Put(
            [FromServices] IHandler<UpdateRegionCommand> handler,
            [FromBody] UpdateRegionCommand command)
        {
            return handler.Handle(command);
        }
        [HttpDelete]
        public HandlerResult<DeleteRegionCommand> Delete(
            [FromServices] IHandler<DeleteRegionCommand> handler,
            [FromBody] DeleteRegionCommand command)
        {
            return handler.Handle(command);
        }
    }
}