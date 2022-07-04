using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Categories.Requests.Queries
{
    public record GetCategoryByIdQuery(string Id) : IRequest<ServiceResponse<CategoryDto>>;
}
