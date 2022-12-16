using System.Net.Http.Json;
using BlazorModel.Models;

namespace AssignmentCSharp6.Service;

public class SinhVienApi : ISinhVienAPI
{
    public HttpClient _HttpClient;

    public SinhVienApi(HttpClient httpClient)
    {
        _HttpClient = httpClient;
    }

    public async Task<List<SinhVien>> GetList()
    {
        var result = await _HttpClient.GetFromJsonAsync<List<SinhVien>>("api/SinhViens/");
        return result!;
    }

    public async Task<bool> Create(SinhVien sinhVien)
    {
        var result = await _HttpClient.PostAsJsonAsync("api/SinhViens/", sinhVien);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Update(int id, SinhVien sinhVien)
    {
        var result = await _HttpClient.PutAsJsonAsync($"api/SinhViens/{id}", sinhVien);
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Delete(int id)
    {
        var result = await _HttpClient.DeleteAsync($"api/SinhViens/{id}");
        return result.IsSuccessStatusCode;
    }

    public async Task<SinhVien> GetById(int id)
    {
        var result = await _HttpClient.GetFromJsonAsync<SinhVien>($"api/SinhViens/{id}");
        return result!;
    }
}