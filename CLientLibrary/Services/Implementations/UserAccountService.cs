using BaseLibraty.DTOs;
using BaseLibraty.Responses;
using CLientLibrary.Services.Contracts;

namespace CLientLibrary.Services.Implementations;

public class UserAccountService : IUserAccountService
{
    public Task<GeneralResponse> CreateAsync(Register user)
    {
        throw new NotImplementedException();
    }
    public Task<LoginResponse> SignInAsync(Login user)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponse> RefreshTokenAsync(RefreshToken user)
    {
        throw new NotImplementedException();
    }

}
