using Application.Contracts.Identities;
using Application.Dtos;
using Application.Features.Auths.Requests.Commands;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Handlers.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ServiceResponse<RegisterResponseDto>>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ServiceResponse<RegisterResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.Register(request.RegisterRequestDto);
            return result;
        }
    }
}
