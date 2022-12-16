using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories;

public class MonHocRespositories : IMonHocRespositories
{
    private readonly CSharp6AssignmentContext _context;
    public MonHocRespositories(CSharp6AssignmentContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<MonHoc>> GetList()
    {
        return await _context.MonHocs.ToListAsync();
    }

    public async Task<MonHoc> Create(MonHoc monHoc)
    {
        await _context.MonHocs.AddAsync(monHoc);
        await _context.SaveChangesAsync();
        return monHoc;
    }

    public async Task<MonHoc> Update(MonHoc monHoc)
    {
        _context.Entry(monHoc).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return monHoc;
    }

    public async Task<MonHoc> Delete(string id)
    {
        var delete = await _context.MonHocs.FindAsync(id);
        _context.MonHocs.Remove(delete!);
        await _context.SaveChangesAsync();
        return delete;
    }

    public async Task<MonHoc> GetById(string id)
    {
        return (await _context.MonHocs.FindAsync(id))!;
    }
}