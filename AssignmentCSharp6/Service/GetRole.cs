using System.Net.Http.Json;
using BlazorModel.Models;

namespace AssignmentCSharp6.Service;

public class GetRole : Igetrole
{
    public HttpClient _HttpClient;

    public GetRole(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<List<Role>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<Role>>("api/Roles/");
        return result!;
    }
}