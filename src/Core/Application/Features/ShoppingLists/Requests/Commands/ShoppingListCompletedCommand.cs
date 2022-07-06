using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Requests.Commands
{
    public record ShoppingListCompletedCommand(string Id, bool IsCompleted) : IRequest<BaseResponse>;
}
