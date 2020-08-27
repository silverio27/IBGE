using System.Collections.Generic;
using System.Threading.Tasks;
using Ibge.Domain.RegionIbgeContext.Commands.Contracts;

namespace Ibge.Domain.RegionIbgeContext.Handlers.Contract
{
    public interface IExecute<T>  where T: ICommand
    {
        Task<IEnumerable<HandlerResult<T>>> Execute();        
    }
}