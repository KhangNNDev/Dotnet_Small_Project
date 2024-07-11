namespace TestLogin.Payload.Response
{
    public class BaseResponse
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "";
        public Object Data { get; set; }
    }
}
