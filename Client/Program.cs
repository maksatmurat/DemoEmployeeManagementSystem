using Blazored.LocalStorage;
using Client;
using CLientLibrary.Helpers;
using CLientLibrary.Services;
using CLientLibrary.Services.Contracts;
using CLientLibrary.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7047");
});

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7047") });
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<LoadingService>();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

await builder.Build().RunAsync();
