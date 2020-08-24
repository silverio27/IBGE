namespace Ibge.Domain.Handlers.Contract
{
    public class SuccessResult<T> : IGenericResult
    {
        public SuccessResult(string message, T data)
        {
            Success = true;
            Message = message;
            Data = data;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
    }


}