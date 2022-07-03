using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.StockUnits.Requests.Commands
{
    public record CreateStockUnitCommand(string Name) : IRequest<ServiceResponse<StockUnitDto>>;
}
