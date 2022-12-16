using BlazorModel.Models;

namespace AssignmentCSharp6.Service;

public interface Igetrole
{
    Task<List<Role>> GetList();
}