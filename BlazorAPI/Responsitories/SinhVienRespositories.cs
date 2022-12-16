using BlazorModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Responsitories;

public class SinhVienRespositories : ISinhVienResponsitories
{
    private readonly CSharp6AssignmentContext _context;
    public SinhVienRespositories(CSharp6AssignmentContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<SinhVien>> GetList()
    {
        return await _context.SinhViens.ToListAsync();
    }

    public async Task<SinhVien> Create(SinhVien sinhVien)
    {
        await _context.SinhViens.AddAsync(sinhVien);
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<SinhVien> Update(SinhVien sinhVien)
    {
        _context.Entry(sinhVien).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<SinhVien> Delete(int id)
    {
        var delete = await _context.SinhViens.FindAsync(id);
        _context.SinhViens.Remove(delete!);
        await _context.SaveChangesAsync();
        return delete;
    }

    public async Task<SinhVien> GetById(int id)
    {
        return (await _context.SinhViens.FindAsync(id))!;
    }
}