using System.Collections.Generic;

namespace Ibge.Domain.Handlers.Contract
{
    public interface IHandler<T> where T : class
    {
        IGenericResult Handle(T command);
        IGenericResult Handle(IEnumerable<T> command);
    }
}