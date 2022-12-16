using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories;

public class GetRole : IGetRole
{
    private readonly CSharp6AssignmentContext _context;

    public GetRole(CSharp6AssignmentContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Role>> GetList()
    {
        return await _context.Roles.ToListAsync();
    }
}