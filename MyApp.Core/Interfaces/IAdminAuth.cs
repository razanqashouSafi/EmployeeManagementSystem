using MyApp.Core.DTOs.Request;
using MyApp.Core.DTOs.Response;

namespace MyApp.Core.Interfaces
{
    public interface IAdminAuth
    {

        public Task<string> Signup(SignupAdmnDTO input);

        public Task<LoginResult> Login(LoginReqDTO input);


    }
}
