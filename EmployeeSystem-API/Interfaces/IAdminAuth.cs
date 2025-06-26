using EmployeeSystem_API.DTOs.Request;

namespace EmployeeSystem_API.Interfaces
{
    public interface IAdminAuth
    {

        public Task<string> Signup(SignupAdmnDTO input);

        public Task<string> Login(String email, string pass);


    }
}
