using Ibge.Domain.RegionIbgeContext.Commands.Contracts;

namespace Ibge.Domain.RegionIbgeContext.Handlers.Contract
{
    public interface IHandler<T> where T : ICommand
    {
        HandlerResult<T> Handle(T command );
    }
}