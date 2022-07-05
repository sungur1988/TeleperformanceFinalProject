using Application.Dtos;
using Application.Models;
using Application.Wrapper;
using System.Security.Claims;

namespace Application.Contracts.Identities
{
    public interface IUserService
    {
        Task<ServiceResponse<AppUser>> CreateUserAsync(RegisterRequestDto registerRequestDto);
        Task<AppUser> GetUser(string id);
        Task<IList<Claim>> GetClaims(AppUser appUser);
        Task<IList<string>> GetRoles(AppUser appUser);
    }
}
