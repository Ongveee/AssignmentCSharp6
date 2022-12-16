using BlazorModel.Models;

namespace BlazorAPI.Responsitories
{
    public interface IUserInteraction
    {
        Task<Account> SignIn(LoginRequest loginRequest);

        Task<Account> Register(Account account);

        Task<Account> Update(Account account);

        Task<Account> FindAccount(string username);
    }
}