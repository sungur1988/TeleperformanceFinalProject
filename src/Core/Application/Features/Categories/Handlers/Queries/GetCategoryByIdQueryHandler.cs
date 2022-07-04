using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Dtos;
using Application.Features.Categories.Requests.Queries;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ServiceResponse<CategoryDto>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryReadRepository.GetById(request.Id);
            if (result==null)
            {
                return new ServiceResponse<CategoryDto>(default, false, 404, Messages.CategoryNotFound);
            }
            return new ServiceResponse<CategoryDto>(_mapper.Map<CategoryDto>(result), true, 200);
        }
    }
}
