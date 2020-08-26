namespace Ibge.Domain.Handlers.Contract
{
    public class HandlerResult<T> 
    {
        public HandlerResult(string message, T data, bool success = true)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }
    }


}