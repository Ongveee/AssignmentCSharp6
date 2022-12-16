using BlazorModel.Models;

namespace BlazorAPI.Responsitories;

public interface ILopRespositories
{
    Task<IEnumerable<Lop>> GetList();

    Task<Lop> Create(Lop lop);
    Task<Lop> Update(Lop lop);
    Task<Lop> Delete(string id);
    Task<Lop> GetById(string id);
}