using Application.Features.ShoppingListItems.Requests.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingListItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateShoppingListItem(CreateShoppingListItemCommand request)
        {
            var result = await _mediator.Send(request);
            switch (result.StatusCode)
            {
                case 404:
                    return NotFound(result);
                    break;
                case 500:
                    return StatusCode((int)StatusCodes.Status500InternalServerError, result);
                    break;
                default:
                    break;
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateShoppingListItem(UpdateShoppingListItemCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingListItem(DeleteShoppingListItemCommand request)
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
