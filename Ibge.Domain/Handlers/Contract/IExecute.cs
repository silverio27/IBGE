using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.Commands.Contracts;

namespace Ibge.Domain.Handlers.Contract
{
    public interface IExecute<T>  where T: ICommand
    {
        Task<IEnumerable<HandlerResult<T>>> Execute();        
    }
}