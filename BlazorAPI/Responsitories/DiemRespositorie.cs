using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories;

public class DiemRespositorie : IDiemRespositories

{
    private readonly CSharp6AssignmentContext _context;
    public DiemRespositorie(CSharp6AssignmentContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Diem>> GetList()
    {
        return await _context.Diems.ToListAsync();
    }

    public async Task<Diem> Create(Diem diem)
    {
        await _context.Diems.AddAsync(diem);
        await _context.SaveChangesAsync();
        return diem;
    }

    public async Task<Diem> Update(Diem diem)
    {
        _context.Entry(diem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return diem;
    }

    public async Task<Diem> Delete(int id)
    {
        var delete = await _context.Diems.FindAsync(id);
        _context.Diems.Remove(delete!);
        await _context.SaveChangesAsync();
        return delete;
    }

    public async Task<Diem> GetById(int id)
    {
        return (await _context.Diems.FindAsync(id))!;
    }
}