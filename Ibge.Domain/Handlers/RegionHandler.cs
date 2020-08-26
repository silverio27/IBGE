using System.Collections.Generic;
using Flunt.Notifications;
using Ibge.Domain.Commands;
using Ibge.Domain.Entities;
using Ibge.Domain.Handlers.Contract;
using Ibge.Domain.Mapping;
using Ibge.Domain.Repositories;

namespace Ibge.Domain.Handlers
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