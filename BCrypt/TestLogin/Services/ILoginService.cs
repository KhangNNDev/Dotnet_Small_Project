using TestLogin.Payload.Request;
using TestLogin.Payload.Response;

namespace TestLogin.Services
{
    public interface ILoginService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
