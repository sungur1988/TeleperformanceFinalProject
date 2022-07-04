using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Categories.Requests.Commands
{
    public record UpdateCategoryCommand(string Id,string Name): IRequest<ServiceResponse<CategoryDto>>;
}
