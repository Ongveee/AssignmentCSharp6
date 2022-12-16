using BlazorModel.Models;

namespace AssignmentCSharp6.Service
{
    public interface ILopApi
    {
        Task<List<Lop>> GetList();

        Task<bool> Create(Lop lop);

        Task<bool> Update(string id, Lop lop);

        Task<bool> Delete(string id);

        Task<Lop> GetById(string id);
    }
}