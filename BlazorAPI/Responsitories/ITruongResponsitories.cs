using BlazorModel.Models;

namespace BlazorAPI.Responsitories;

public interface ITruongResponsitories
{
    Task<IEnumerable<Truong>> GetList();

    Task<Truong> Create(Truong truong);
    Task<Truong> Update(Truong truong);
    Task<Truong> Delete(string id);
    Task<Truong> GetById(string id);
}