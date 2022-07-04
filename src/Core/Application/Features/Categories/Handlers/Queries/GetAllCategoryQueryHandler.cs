﻿using Application.Contracts.Repositories.ReadRepositories;
using Application.Dtos;
using Application.Features.Categories.Requests.Queries;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Handlers.Queries
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ServiceResponse<IEnumerable<CategoryDto>>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public  Task<ServiceResponse<IEnumerable<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result =  _categoryReadRepository.GetAll().Skip((request.PageNumber-1)*request.PageSize).Take(request.PageSize).AsEnumerable();
            return Task.FromResult(new ServiceResponse<IEnumerable<CategoryDto>>(_mapper.Map<IEnumerable<CategoryDto>>(result), true, 200));
        }
    }
}