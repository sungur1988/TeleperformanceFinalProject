using Application.Contracts.Cache;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Features.ShoppingLists.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICacheManager _cacheManager;

        public ShoppingListsController(IMediator mediator, ICacheManager cacheManager)
        {
            _mediator = mediator;
            _cacheManager = cacheManager;
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
            if (_cacheManager.IsAdd(id))
            {
                var data = _cacheManager.Get(id);
                return Ok(data);
            }
            
            var request = new GetShoppingListByIdQuery(id);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
                return NotFound(result);
            _cacheManager.Add(id, result, 15);
            return Ok(result);
        }
        [Authorize(Roles ="Admin")]
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
        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingList(DeleteShoppingListCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpPut("IsComplete")]
        public async Task<IActionResult> CompleteShoppingList(ShoppingListCompletedCommand request)
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
