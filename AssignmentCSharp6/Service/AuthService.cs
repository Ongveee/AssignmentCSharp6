using Blazored.LocalStorage;
using BlazorModel.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AssignmentCSharp6.Service
{
    public class AuthService : IAuthServicecs
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResult> Login(LoginRequest loginRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Accounts/auth/login", loginRequest);
            var content = await result.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResult>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            if (!result.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await _localStorage.SetItemAsync("authToken", loginResponse.token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.username);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.token);
            return loginResponse;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}