using Application.Features.StockUnits.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [HttpPut]
        public async Task<IActionResult> UpdateStockUnit(UpdateStockUnitCommand request)
        {
            var result = await _mediator.Send(request);
            switch (result.StatusCode)
            {
                case 404:
                    return NotFound(result);
                    break;
                case 500:
                    return StatusCode((int)StatusCodes.Status500InternalServerError,result);
                    break;
                default:
                    break;
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteStockUnit(DeleteStockUnitCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
