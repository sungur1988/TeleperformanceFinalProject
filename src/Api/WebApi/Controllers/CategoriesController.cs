using Application.Features.Categories.Requests.Commands;
using Application.Features.Categories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand request)
        {
            var result=await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var request = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(request);
            if(!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategory(int pageNumber,int pageSize)
        {
            var request = new GetAllCategoryQuery(pageNumber, pageSize);
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
