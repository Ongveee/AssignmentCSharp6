using System.Net.Http.Json;
using BlazorModel.Models;

namespace AssignmentCSharp6.Service;

public class NganhApi : INganhApi
{
    public HttpClient _HttpClient;

    public NganhApi(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<List<Nganh>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<Nganh>>("api/Nganhs/");
        return result!;
    }

    public async Task<bool> Create(Nganh nganh)
    {
        var result = await _HttpClient.PostAsJsonAsync("api/Nganhs/", nganh);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Update(string id, Nganh nganh)
    {
        var result = await _HttpClient.PutAsJsonAsync($"api/Nganhs/{id}", nganh);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _HttpClient.DeleteAsync($"api/Nganhs/{id}");
        return result.IsSuccessStatusCode;
    }

    public async Task<Nganh> GetById(string id)
    {
        var result = await _HttpClient.GetFromJsonAsync<Nganh>($"api/Nganhs/{id}");
        return result!;
    }
}