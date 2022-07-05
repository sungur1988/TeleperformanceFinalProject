using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Requests.Commands
{
    public record DeleteShoppingListCommand(string Id) : IRequest<BaseResponse>;
}
