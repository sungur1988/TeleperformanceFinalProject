using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Requests.Queries
{
    public record GetShoppingListByIdQuery(string Id) : IRequest<ServiceResponse<ShoppingListDto>>;
}
