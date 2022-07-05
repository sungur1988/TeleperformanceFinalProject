using Application.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Contracts.Identities
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser appUser);
    }
}
