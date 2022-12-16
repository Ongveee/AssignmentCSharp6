using BlazorModel.Models;

namespace BlazorAPI.Responsitories;

public interface IDiemRespositories
{
    Task<IEnumerable<Diem>> GetList();

    Task<Diem> Create(Diem diem);
    Task<Diem> Update(Diem diem);
    Task<Diem> Delete(int id);
    Task<Diem> GetById(int id);
}