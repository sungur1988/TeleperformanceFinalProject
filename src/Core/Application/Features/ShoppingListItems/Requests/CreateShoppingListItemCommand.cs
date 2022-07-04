using Application.Dtos;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ShoppingListItems.Requests
{
    public record CreateShoppingListItemCommand(string Name,string StockUnitId) : IRequest<ServiceResponse<ShoppingListItemDto>>;
}
