using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories;

public class TruongRespositories : ITruongResponsitories
{
    private readonly CSharp6AssignmentContext _context;
    public TruongRespositories(CSharp6AssignmentContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Truong>> GetList()
    {
        return await _context.Truongs.ToListAsync();
    }

    public async Task<Truong> Create(Truong truong)
    {
        await _context.Truongs.AddAsync(truong);
        await _context.SaveChangesAsync();
        return truong;
    }

    public async Task<Truong> Update(Truong truong)
    {
        _context.Entry(truong).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return truong;
    }

    public async Task<Truong> Delete(string id)
    {
        var delete = await _context.Truongs.FindAsync(id);
        _context.Truongs.Remove(delete!);
        await _context.SaveChangesAsync();
        return delete;
    }

    public async Task<Truong> GetById(string id)
    {
        return (await _context.Truongs.FindAsync(id))!;
    }
}