using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ibge.Domain.Infra.Contexts;
using Ibge.Domain.Infra.Repositories;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Handlers;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Queries;
using Ibge.Domain.RegionIbgeContext.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        public HandlerResult<CreateRegionCommand> Post(
            [FromServices] IHandler<CreateRegionCommand> handler,
            [FromBody] CreateRegionCommand command)
        {
            return handler.Handle(command);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(
            [FromServices] DataContext context,
            [FromBody] Region region,
            int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    Mesage = "Os campos não correspondem aos campos de uma região.",
                    State = ModelState.ToList()
                });

            var model = context.Region.FirstOrDefault(RegionQueries.GetRegionById(id));
            if (model == null)
                return NotFound(new { Mensagem = "A região não foi encontrada" });

            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(region);
        }
        [HttpPost("integration")]
        public async Task<IEnumerable<HandlerResult<CreateRegionCommand>>> Integration(
            [FromServices] RegionIntegrationHandler handler
        )
        {
            return await handler.Execute();
        }
    }
}