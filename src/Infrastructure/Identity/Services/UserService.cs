using Application.Contracts.Identities;
using Application.Dtos;
using Application.Models;
using Application.Wrapper;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AppUser>> CreateUserAsync(RegisterRequestDto registerRequestDto)
        {
            var appUser = _mapper.Map<AppUser>(registerRequestDto);
            var result = await _userManager.CreateAsync(appUser, registerRequestDto.Password);
            if (result.Succeeded)
            {
                return new ServiceResponse<AppUser>(appUser, true, 204);
            }
            return new ServiceResponse<AppUser>(default, false, 500);
        }

        public Task<AppUser> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Claim>> GetClaims(AppUser appUser)
        {
            return await _userManager.GetClaimsAsync(appUser);
        }

        public async Task<IList<string>> GetRoles(AppUser appUser)
        {
            return await _userManager.GetRolesAsync(appUser);
        }
    }
}
