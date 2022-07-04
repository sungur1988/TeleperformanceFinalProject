using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Categories.Requests.Queries
{
    public record GetAllCategoryQuery(int PageNumber,int PageSize) : IRequest<ServiceResponse<IEnumerable<CategoryDto>>>;
}
