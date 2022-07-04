using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingListItems.Requests.Commands
{
    public record UpdateShoppingListItemCommand(string Id, string Name, bool IsPurchased, int Amount) : IRequest<ServiceResponse<ShoppingListItemUpdateDto>>;
}
