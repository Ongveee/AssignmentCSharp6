using BlazorModel.Models;

namespace AssignmentCSharp6.Service;

public interface IMonHocAPI
{
    Task<List<MonHoc>> GetList();

    Task<bool> Create(MonHoc monHoc);

    Task<bool> Update(string id, MonHoc monHoc);

    Task<bool> Delete(string id);

    Task<MonHoc> GetById(string id);
}