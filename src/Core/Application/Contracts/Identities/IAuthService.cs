using Application.Dtos;
using Application.Wrapper;

namespace Application.Contracts.Identities
{
    public interface IAuthService
    {
        Task<ServiceResponse<RegisterResponseDto>> Register(RegisterRequestDto registerRequestDto);
        Task<ServiceResponse<string>> Login(LoginRequestDto loginRequestDto);
    }
}
