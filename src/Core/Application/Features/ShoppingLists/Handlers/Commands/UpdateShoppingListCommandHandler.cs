using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Commands
{
    public class UpdateShoppingListCommandHandler : IRequestHandler<UpdateShoppingListCommand, ServiceResponse<ShoppingListDto>>
    {
        private readonly IShoppingListReadRepository _shoppingListReadRepository;
        private readonly IShoppingListWriteRepository _shoppingListWriteRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public UpdateShoppingListCommandHandler(IShoppingListReadRepository shoppingListReadRepository, IShoppingListWriteRepository shoppingListWriteRepository, IMapper mapper, ICategoryReadRepository categoryReadRepository)
        {
            _shoppingListReadRepository = shoppingListReadRepository;
            _shoppingListWriteRepository = shoppingListWriteRepository;
            _mapper = mapper;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<ServiceResponse<ShoppingListDto>> Handle(UpdateShoppingListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _shoppingListReadRepository.GetById(request.Id);
                if (entityToUpdate == null)
                {
                    return new ServiceResponse<ShoppingListDto>(default, false, 404, Messages.ShoppingListNotFound);
                }
                var categoryToAdd = await _categoryReadRepository.GetById(request.CategoryId);
                if (categoryToAdd == null)
                {
                    return new ServiceResponse<ShoppingListDto>(default, false, 404, Messages.CategoryNotFound);
                }
                entityToUpdate.Category = categoryToAdd;
                var result = _shoppingListWriteRepository.Update(entityToUpdate);
                return new ServiceResponse<ShoppingListDto>(_mapper.Map<ShoppingListDto>(result), true, 200, Messages.ShoppingListUpdated);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
