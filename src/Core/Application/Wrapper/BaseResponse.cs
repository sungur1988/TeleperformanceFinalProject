namespace Application.Wrapper
{
    public class BaseResponse
    {
        public BaseResponse(bool isSuccess,int statusCode)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
        }
        public BaseResponse(bool isSuccess,int statusCode, string message) : this(isSuccess,statusCode)
        {
            Message = message;
        }

        public string Message { get; set; }

        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
    }
}
