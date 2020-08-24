namespace Ibge.Domain.Handlers.Contract
{
    public interface IGenericResult
    {
        bool Success { get;}
        string Message { get;  }
    }
}