using Application.Contracts.Identities;
using Application.Features.Auths.Requests.Commands;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Auths.Handlers.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResponse<string>>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ServiceResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(request.LoginRequestDto);
            if (!result.IsSuccess)
                return new ServiceResponse<string>(default, false, result.StatusCode, result.Message);
            return new ServiceResponse<string>(result.Value,true,200 ,result.Message);
        }
    }

}
