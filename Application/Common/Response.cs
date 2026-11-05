namespace Application.Common
{
    public class Response<T>
    {
        public Status Status { get; set; }
        public T? Data { get; set; }

        // Success response
        public static Response<T> SuccessResponse(T data, string message = "Request completed successfully")
        {
            return new Response<T>
            {
                Status = new Status
                {
                    Success = true,
                    Message = message
                },
                Data = data
            };
        }

        // Error response
        public static Response<T> ErrorResponse(string message)
        {
            return new Response<T>
            {
                Status = new Status
                {
                    Success = false,
                    Message = message
                },
                Data = default
            };
        }
    }

    public class Status
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
