namespace PartyManager.Application.Shared.Responding
{
    public class Response<T> : Response
    {
        public T Payload { get; internal set; }

        internal static Response<T> Succeed(T payload, StatusCode statusCode, string message)
        {
            return new Response<T>
            {
                Payload = payload,
                StatusCode = statusCode,
                Success = true,
                Message = message
            };
        }
    }

    public class Response
    {
        public bool Success { get; internal set; }
        
        public string Message { get; internal set; }

        public StatusCode StatusCode { get; internal set; }

        internal static Response Succeed(StatusCode statusCode, string message)
        {
            return new Response
            {
                StatusCode = statusCode,
                Success = true,
                Message = message
            };
        }

        internal static Response Fail(StatusCode statusCode, string message)
        {
            return new Response
            {
                StatusCode = statusCode,
                Success = false,
                Message = message
            };
        }
    }
}