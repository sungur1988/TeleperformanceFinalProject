using Application.Dtos;
using Application.Models;
using Application.Wrapper;
using System.Security.Claims;

namespace Application.Contracts.Identities
{
    public interface IUserService
    {
        Task<ServiceResponse<AppUser>> CreateUserAsync(RegisterRequestDto registerRequestDto);
        Task<ServiceResponse<AppUser>> GetUser(string email);
        Task<bool> Login(AppUser user,string password);
        Task<IList<Claim>> GetClaims(AppUser appUser);
        Task<IList<string>> GetRoles(AppUser appUser);
    }
}
