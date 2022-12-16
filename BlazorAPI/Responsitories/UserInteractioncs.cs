using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories
{
    public class UserInteractioncs : IUserInteraction
    {
        private readonly CSharp6AssignmentContext _context;

        public UserInteractioncs(CSharp6AssignmentContext context)
        {
            _context = context;
        }

        public async Task<Account> Register(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> FindAccount(string username)
        {
            return (await _context.Accounts.FindAsync(username))!;
        }

        public async Task<Account> SignIn(LoginRequest loginRequest)
        {
            return await _context.Accounts.FirstOrDefaultAsync(c => c.Username == loginRequest.username && c.Password == loginRequest.password);
        }
    }
}