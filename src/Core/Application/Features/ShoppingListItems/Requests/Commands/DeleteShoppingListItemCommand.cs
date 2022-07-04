using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingListItems.Requests.Commands
{
    public record DeleteShoppingListItemCommand(string Id) : IRequest<BaseResponse>;
}
