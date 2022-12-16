using BlazorModel.Models;

namespace BlazorAPI.Responsitories;

public interface INganhResponsitories
{
    Task<IEnumerable<Nganh>> GetList();

    Task<Nganh> Create(Nganh nganh);
    Task<Nganh> Update(Nganh nganh);
    Task<Nganh> Delete(string id);
    Task<Nganh> GetById(string id);
}