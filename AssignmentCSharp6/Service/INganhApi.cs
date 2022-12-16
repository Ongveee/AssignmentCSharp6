using BlazorModel.Models;

namespace AssignmentCSharp6.Service
{
    public interface INganhApi
    {
        Task<List<Nganh>> GetList();

        Task<bool> Create(Nganh nganh);

        Task<bool> Update(string id, Nganh nganh);

        Task<bool> Delete(string id);

        Task<Nganh> GetById(string id);
    }
}