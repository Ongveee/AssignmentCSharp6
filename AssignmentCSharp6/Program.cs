using AssignmentCSharp6;
using AssignmentCSharp6.Service;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IDiemApi, DiemApi>();
builder.Services.AddScoped<ITruongApi, TruongAPI>();
builder.Services.AddScoped<ISinhVienAPI, SinhVienApi>();
builder.Services.AddScoped<INganhApi, NganhApi>();
builder.Services.AddScoped<ILopApi, LopApi>();
builder.Services.AddScoped<IMonHocAPI, MonHocApi>();
builder.Services.AddScoped<IAuthServicecs, AuthService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7195") });

await builder.Build().RunAsync();
