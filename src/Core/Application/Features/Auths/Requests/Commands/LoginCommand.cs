using Application.Dtos;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Requests.Commands
{
    public record LoginCommand(LoginRequestDto LoginRequestDto):IRequest<ServiceResponse<string>>;
}
