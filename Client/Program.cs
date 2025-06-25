using BaseLibraty.Entities;
using Blazored.LocalStorage;
using Client;
using Client.ApplicationStates;
using CLientLibrary.Helpers;
using CLientLibrary.Services;
using CLientLibrary.Services.Contracts;
using CLientLibrary.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using Syncfusion.Licensing;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXlcdXRWQ2NeWEF/WkpWYUA=");

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7047");
}).AddHttpMessageHandler<CustomHttpHandler>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7047") });
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<LoadingService>();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();


//General Department / Department / Branch
builder.Services.AddScoped<IGenericServiceInterface<GeneralDepartment>, GenericServiceImplementation<GeneralDepartment>>();
builder.Services.AddScoped<IGenericServiceInterface<Department>, GenericServiceImplementation<Department>>();
builder.Services.AddScoped<IGenericServiceInterface<Branch>, GenericServiceImplementation<Branch>>();

//Country / City / Town
builder.Services.AddScoped<IGenericServiceInterface<Country>, GenericServiceImplementation<Country>>();
builder.Services.AddScoped<IGenericServiceInterface<City>, GenericServiceImplementation<City>>();
builder.Services.AddScoped<IGenericServiceInterface<Town>, GenericServiceImplementation<Town>>();

//Employee 
builder.Services.AddScoped<IGenericServiceInterface<Employee>, GenericServiceImplementation<Employee>>();



builder.Services.AddScoped<AllState>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();

await builder.Build().RunAsync();
