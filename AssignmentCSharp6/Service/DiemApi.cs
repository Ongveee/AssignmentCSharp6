using System.Net.Http.Json;
using Diem = BlazorModel.Models.Diem;

namespace AssignmentCSharp6.Service;

public class DiemApi : IDiemApi
{
    public HttpClient _HttpClient;

    public DiemApi(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<bool> Create(Diem diem)
    {
        var result = await _HttpClient.PostAsJsonAsync("api/Diems/", diem);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _HttpClient.DeleteAsync($"api/Diems/{id}");
        return result.IsSuccessStatusCode;
    }

    public async Task<Diem> GetById(int id)
    {
        var result = await _HttpClient.GetFromJsonAsync<Diem>($"api/Diems/{id}");
        return result!;
    }

    public async Task<List<Diem>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<Diem>>("api/Diems/");
        return result!;
    }

    public async Task<bool> Update(int id, Diem diem)
    {
        var result = await _HttpClient.PostAsJsonAsync($"api/Diems/{id}", diem);
        return result.IsSuccessStatusCode;
    }
}