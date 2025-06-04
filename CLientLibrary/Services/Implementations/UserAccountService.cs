using BaseLibraty.DTOs;
using BaseLibraty.Responses;
using CLientLibrary.Helpers;
using CLientLibrary.Services.Contracts;
using System.Net.Http.Json;

namespace CLientLibrary.Services.Implementations;

public class UserAccountService(GetHttpClient getHttpClient) : IUserAccountService
{
    public const string AuthUrl = "api/authentication";
    public async Task<GeneralResponse> CreateAsync(Register user)
    {
        var httpClient = getHttpClient.GetPublicHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/register", user);
        if(!result.IsSuccessStatusCode)
        {
            return new GeneralResponse(false, "Registration failed. Please try again.");
        }
        return await result.Content.ReadFromJsonAsync<GeneralResponse>() ?? new GeneralResponse(false, "Registration failed. Please try again.");

    }
    public async Task<LoginResponse> SignInAsync(Login user)
    {
        var httpClient = getHttpClient.GetPublicHttpClient();
        var result = await httpClient.PostAsJsonAsync($"{AuthUrl}/login", user);
        if (!result.IsSuccessStatusCode) return new LoginResponse(false, "Login failed. Please try again.");
        return await result.Content.ReadFromJsonAsync<LoginResponse>() ?? new LoginResponse(false, "Login failed. Please try again.");

    }

    public Task<LoginResponse> RefreshTokenAsync(RefreshToken user)
    {
        throw new NotImplementedException();
    }

}
