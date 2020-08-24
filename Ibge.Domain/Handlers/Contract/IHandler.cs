using System.Collections.Generic;

namespace Ibge.Domain.Handlers.Contract
{
    public interface IHandler<T>
    {
        IGenericResult Handle(T command);
    }
}