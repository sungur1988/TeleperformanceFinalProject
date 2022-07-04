using Application.Wrapper;
using MediatR;

namespace Application.Features.Categories.Requests.Commands
{
    public record DeleteCategoryCommand(string Id) : IRequest<BaseResponse>;
}
