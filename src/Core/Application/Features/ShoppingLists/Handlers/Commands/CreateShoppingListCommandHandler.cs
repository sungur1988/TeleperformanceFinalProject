using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Commands
{
    public class CreateShoppingListCommandHandler : IRequestHandler<CreateShoppingListCommand, ServiceResponse<ShoppingListDto>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IShoppingListWriteRepository _shoppingListWriteRepository;
        private readonly IMapper _mapper;

        public CreateShoppingListCommandHandler(ICategoryReadRepository categoryReadRepository, IShoppingListWriteRepository shoppingListWriteRepository,  IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _shoppingListWriteRepository = shoppingListWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShoppingListDto>> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd = _mapper.Map<ShoppingList>(request);
            var categoryToAdd = await _categoryReadRepository.GetById(request.CategoryId);
            if (categoryToAdd==null)
            {
                return new ServiceResponse<ShoppingListDto>(default, false, 404, Messages.CategoryNotFound);
            }
            entityToAdd.Category = categoryToAdd;
            var result = await _shoppingListWriteRepository.AddAsync(entityToAdd);
            return new ServiceResponse<ShoppingListDto>(_mapper.Map<ShoppingListDto>(result), true, 204, Messages.ShoppingListCreated);
            throw new NotImplementedException();
        }
    }
}
