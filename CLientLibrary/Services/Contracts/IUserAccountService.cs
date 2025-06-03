using BaseLibraty.DTOs;
using BaseLibraty.Responses;

namespace CLientLibrary.Services.Contracts;

public interface IUserAccountService
{
    Task<GeneralResponse> CreateAsync(Register user);
    Task<LoginResponse> SignInAsync(Login user);
    Task<LoginResponse> RefreshTokenAsync(RefreshToken user);
}
