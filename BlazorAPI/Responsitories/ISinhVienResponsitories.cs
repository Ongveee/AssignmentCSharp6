using BlazorModel.Models;

namespace BlazorAPI.Responsitories;

public interface ISinhVienResponsitories
{
    Task<IEnumerable<SinhVien>> GetList();

    Task<SinhVien> Create(SinhVien sinhVien);
    Task<SinhVien> Update(SinhVien sinhVien);
    Task<SinhVien> Delete(int id);
    Task<SinhVien> GetById(int id);
}