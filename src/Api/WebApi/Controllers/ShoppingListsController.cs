using Application.Features.ShoppingLists.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShoppingListsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateShoppingList(CreateShoppingListCommand request)
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
    }
}
