using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories;

public class LopRespositories : ILopRespositories
{
    private readonly CSharp6AssignmentContext _context;
    public LopRespositories(CSharp6AssignmentContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Lop>> GetList()
    {
        return await _context.Lops.ToListAsync();
    }

    public async Task<Lop> Create(Lop lop)
    {
        await _context.Lops.AddAsync(lop);
        await _context.SaveChangesAsync();
        return lop;
    }

    public async Task<Lop> Update(Lop lop)
    {
        _context.Entry(lop).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return lop;
    }

    public async Task<Lop> Delete(string id)
    {
        var delete = await _context.Lops.FindAsync(id);
        _context.Lops.Remove(delete!);
        await _context.SaveChangesAsync();
        return delete;
    }

    public async Task<Lop> GetById(string id)
    {
        return (await _context.Lops.FindAsync(id))!;
    }
}