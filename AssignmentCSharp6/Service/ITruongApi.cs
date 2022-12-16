using BlazorModel.Models;

namespace AssignmentCSharp6.Service;

public interface ITruongApi
{
    Task<List<Truong>> GetList();

    Task<bool> Create(Truong truong);

    Task<bool> Update(string id, Truong truong);

    Task<bool> Delete(string id);

    Task<Truong> GetById(string id);
}