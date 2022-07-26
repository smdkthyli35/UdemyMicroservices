using IdentityModel.Client;
using UdemyMicroservices.Common.Dtos;
using WebApp.Models;

namespace WebApp.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signinInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
