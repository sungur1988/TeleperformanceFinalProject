using Application.Features.ShoppingLists.Requests.Commands;
using Application.Features.ShoppingLists.Requests.Queries;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingListById(string id)
        {
            var request = new GetShoppingListByIdQuery(id);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingLists(int pageNumber, int pageSize,string? keyword)
        {
            var request = new GetAllShoppingListQuery(pageNumber, pageSize,keyword);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateShoppingList(UpdateShoppingListCommand request)
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
