using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories;

public class NganhRespositories : INganhResponsitories
{
    private readonly CSharp6AssignmentContext _context;
    public NganhRespositories(CSharp6AssignmentContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Nganh>> GetList()
    {
        return await _context.Nganhs.ToListAsync();
    }

    public async Task<Nganh> Create(Nganh nganh)
    {
        await _context.Nganhs.AddAsync(nganh);
        await _context.SaveChangesAsync();
        return nganh;
    }

    public async Task<Nganh> Update(Nganh nganh)
    {
        _context.Entry(nganh).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return nganh;
    }

    public async Task<Nganh> Delete(string id)
    {
        var delete = await _context.Nganhs.FindAsync(id);
        _context.Nganhs.Remove(delete!);
        await _context.SaveChangesAsync();
        return delete;
    }

    public async Task<Nganh> GetById(string id)
    {
        return (await _context.Nganhs.FindAsync(id))!;
    }
}