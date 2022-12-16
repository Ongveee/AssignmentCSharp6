using BlazorModel.Models;

namespace AssignmentCSharp6.Service
{
    public interface ISinhVienAPI
    {
        Task<List<SinhVien>> GetList();

        Task<bool> Create(SinhVien sinhVien);

        Task<bool> Update(int id, SinhVien sinhVien);

        Task<bool> Delete(int id);

        Task<SinhVien> GetById(int id);
    }
}