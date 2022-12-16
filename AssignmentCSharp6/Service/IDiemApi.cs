using Diem = BlazorModel.Models.Diem;

namespace AssignmentCSharp6.Service;

public interface IDiemApi
{
    Task<List<Diem>> GetList();

    Task<bool> Create(Diem diem);

    Task<bool> Update(int id, Diem diem);

    Task<bool> Delete(int id);

    Task<Diem> GetById(int id);
}