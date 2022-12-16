using BlazorModel.Models;

namespace BlazorAPI.Responsitories;

public interface IMonHocRespositories
{
    Task<IEnumerable<MonHoc>> GetList();

    Task<MonHoc> Create(MonHoc monHoc);
    Task<MonHoc> Update(MonHoc monHoc);
    Task<MonHoc> Delete(string id);
    Task<MonHoc> GetById(string id);
}