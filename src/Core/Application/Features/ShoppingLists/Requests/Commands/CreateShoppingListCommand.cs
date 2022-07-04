using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Requests.Commands
{
    public record CreateShoppingListCommand(string name,string CategoryId,string Note,IEnumerable<ShoppingListItemDto>ShoppingListItems) : IRequest<ServiceResponse<ShoppingListDto>>;
}
