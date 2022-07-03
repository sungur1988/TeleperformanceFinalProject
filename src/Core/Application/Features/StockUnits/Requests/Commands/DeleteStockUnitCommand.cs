using Application.Wrapper;
using MediatR;

namespace Application.Features.StockUnits.Requests.Commands
{
    public record DeleteStockUnitCommand(string Id) : IRequest<BaseResponse>;
}
