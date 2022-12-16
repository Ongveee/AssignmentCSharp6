using BlazorModel.Models;

namespace AssignmentCSharp6.Service
{
    public interface IAuthServicecs
    {
        Task<LoginResult> Login(LoginRequest loginRequest);

        Task Logout();
    }
}