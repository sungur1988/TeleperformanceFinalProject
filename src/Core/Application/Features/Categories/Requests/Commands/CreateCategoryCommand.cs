using Application.Dtos;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Categories.Requests.Commands
{
    public record CreateCategoryCommand(string Name) : IRequest<ServiceResponse<CategoryDto>>;
}
