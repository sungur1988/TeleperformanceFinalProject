using Application.Constants;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.Categories.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ServiceResponse<CategoryDto>>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToAdd = _mapper.Map<Category>(request);
                var result = await _categoryWriteRepository.AddAsync(entityToAdd);
                return new ServiceResponse<CategoryDto>(_mapper.Map<CategoryDto>(result), true, 204, Messages.CategoryCreated);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
