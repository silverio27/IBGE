using System;
using Flunt.Notifications;
using Ibge.Domain.RegionIbgeContext.Commands;
using Ibge.Domain.RegionIbgeContext.Commands.Contracts;
using Ibge.Domain.RegionIbgeContext.Entities;
using Ibge.Domain.RegionIbgeContext.Handlers.Contract;
using Ibge.Domain.RegionIbgeContext.Mapping;
using Ibge.Domain.RegionIbgeContext.Repositories;

namespace Ibge.Domain.RegionIbgeContext.Handlers
{
    public class RegionHandler : Notifiable, 
        IHandler<CreateRegionCommand>,
        IHandler<UpdateRegionCommand>,
        IHandler<DeleteRegionCommand>
    {
        private IRegionRepository _repository;

        public RegionHandler(
            IRegionRepository repository) =>
            _repository = repository;

        public HandlerResult<CreateRegionCommand> Handle(CreateRegionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new HandlerResult<CreateRegionCommand>(
                    "especifique melhor a região", command, false);

            var region = AutoMapperConfiguration.Mapper.Map<Region>(command);

            if (_repository.Exist(region))
                return new HandlerResult<CreateRegionCommand>(
                    "A região já existe", command, false);

            _repository.Create(region);

            return new HandlerResult<CreateRegionCommand>("Região incluída", command);
        }

        public HandlerResult<UpdateRegionCommand> Handle(UpdateRegionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new HandlerResult<UpdateRegionCommand>(
                    "especifique melhor a região", command, false);

            var region = AutoMapperConfiguration.Mapper.Map<Region>(command);

            if (!_repository.Exist(region))
                return new HandlerResult<UpdateRegionCommand>(
                    "A região não existe", command, false);

            _repository.Update(region);

            return new HandlerResult<UpdateRegionCommand>("Região atualizada", command);
        }

        public HandlerResult<DeleteRegionCommand> Handle(DeleteRegionCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new HandlerResult<DeleteRegionCommand>(
                    "especifique melhor a região", command, false);

            var region = AutoMapperConfiguration.Mapper.Map<Region>(command);

            if (!_repository.Exist(region))
                return new HandlerResult<DeleteRegionCommand>(
                    "A região não existe", command, false);

            _repository.Delete(region);

            return new HandlerResult<DeleteRegionCommand>("Região deletada", command);
        }

    
    }
}