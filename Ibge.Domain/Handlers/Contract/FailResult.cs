using System;

namespace Ibge.Domain.Handlers.Contract
{
    public class FailResult : IGenericResult
    {
        public FailResult(string message, Exception exception)
        {
            Success = false;
            Message = message;
            Ex = exception;
        }

        public bool Success { get; }

        public string Message { get; }
        public Exception Ex { get; }
    }
}