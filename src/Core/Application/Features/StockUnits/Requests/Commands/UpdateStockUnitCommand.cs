using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.StockUnits.Requests.Commands
{
    public record UpdateStockUnitCommand(string Id, string Name) : IRequest<ServiceResponse<StockUnitDto>>;
}
