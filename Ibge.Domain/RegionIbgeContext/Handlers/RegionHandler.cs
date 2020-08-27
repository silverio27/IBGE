using Flunt.Notifications;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Mapping;
using Ibge.Domain.RegionIbgeContext.Repositories;

namespace Ibge.Domain.RegionIbgeContext.Handlers
{
    public class RegionHandler : Notifiable, IHandler<RegionCommand>
    {
        private IRegionRepository _repository;

        public RegionHandler(
            IRegionRepository repository) =>
            _repository = repository;

        public HandlerResult<RegionCommand> Handle(RegionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new HandlerResult<RegionCommand>(
                    "especifique melhor a região", command, false);

            var region = AutoMapperConfiguration.Mapper.Map<Region>(command);

            if (_repository.Exist(region))
                return new HandlerResult<RegionCommand>(
                    "A região já existe", command, false);

            _repository.Create(region);

            return new HandlerResult<RegionCommand>("Região incluída", command);
        }

    
    }
}