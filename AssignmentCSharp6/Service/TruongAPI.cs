using BlazorModel.Models;
using System.Net.Http.Json;

namespace AssignmentCSharp6.Service;

public class TruongAPI : ITruongApi
{
    public HttpClient _HttpClient;

    public TruongAPI(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<List<Truong>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<Truong>>("api/Truongs/");
        return result!;
    }

    public async Task<bool> Create(Truong truong)
    {
        var result = await _HttpClient.PostAsJsonAsync("api/Truongs/", truong);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Update(string id, Truong truong)
    {
        var result = await _HttpClient.PutAsJsonAsync($"api/Truongs/{id}", truong);
        return result.IsSuccessStatusCode;
    }

    public async Task<Truong> GetById(string id)
    {
        var result = await _HttpClient.GetFromJsonAsync<Truong>($"api/Truongs/{id}");
        return result!;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _HttpClient.DeleteAsync($"api/Truongs/{id}");
        return result.IsSuccessStatusCode;
    }
}