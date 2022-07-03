namespace Application.Wrapper
{
    public class ServiceResponse<T> : BaseResponse
    {
        public T Value { get; set; }
        public ServiceResponse(T value, bool isSuccess, int statusCode,string message) : base(isSuccess,statusCode,message)
        {
            Value = value;
        }

        public ServiceResponse(T value, bool isSuccess,int statusCode) : base(isSuccess,statusCode)
        {
            Value = value;
        }
    }
}
