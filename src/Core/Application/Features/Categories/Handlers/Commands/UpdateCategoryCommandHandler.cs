using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.Categories.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Handlers.Commands 
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ServiceResponse<CategoryDto>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _categoryReadRepository.GetById(request.Id);
                if (entityToUpdate == null)
                {
                    return new ServiceResponse<CategoryDto>(default, false, 404, Messages.CategoryNotFound);
                }
                entityToUpdate = _mapper.Map(request, entityToUpdate);
                _categoryWriteRepository.Update(entityToUpdate);
                return new ServiceResponse<CategoryDto>(_mapper.Map<CategoryDto>(entityToUpdate), true, 200, Messages.CategoryUpdated);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }

        }
    }
}
