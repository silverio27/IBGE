using System.Collections.Generic;
using Ibge.Domain.Commands.Contracts;

namespace Ibge.Domain.Handlers.Contract
{
    public interface IHandler<T> where T : ICommand
    {
        HandlerResult<T> Handle(T command );
    }
}