using Application.Features.StockUnits.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockUnitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockUnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStockUnit(CreateStockUnitCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
