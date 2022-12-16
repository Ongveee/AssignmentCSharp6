using BlazorModel.Models;

namespace BlazorAPI.Responsitories;

public interface IGetRole
{
    Task<IEnumerable<Role>> GetList();
}