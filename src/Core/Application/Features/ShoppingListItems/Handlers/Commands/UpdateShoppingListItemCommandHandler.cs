using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.ShoppingListItems.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.ShoppingListItems.Handlers.Commands
{
    public class UpdateShoppingListItemCommandHandler : IRequestHandler<UpdateShoppingListItemCommand, ServiceResponse<ShoppingListItemUpdateDto>>
    {
        private readonly IShoppingListItemReadRepository _shoppingListItemReadRepository;
        private readonly IShoppingListItemWriteRepository _shoppingListItemWriteRepository;
        private readonly IMapper _mapper;

        public UpdateShoppingListItemCommandHandler(IShoppingListItemReadRepository shoppingListItemReadRepository, IShoppingListItemWriteRepository shoppingListItemWriteRepository, IMapper mapper)
        {
            _shoppingListItemReadRepository = shoppingListItemReadRepository;
            _shoppingListItemWriteRepository = shoppingListItemWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShoppingListItemUpdateDto>> Handle(UpdateShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _shoppingListItemReadRepository.GetById(request.Id);
            if (entityToUpdate == null)
            {
                return new ServiceResponse<ShoppingListItemUpdateDto>(default, false, 404, Messages.ShoppingListItemNotFound);
            }
            entityToUpdate = _mapper.Map(request, entityToUpdate);
            _shoppingListItemWriteRepository.Update(entityToUpdate);
            return new ServiceResponse<ShoppingListItemUpdateDto>(_mapper.Map<ShoppingListItemUpdateDto>(entityToUpdate), true, 200, Messages.ShoppingListItemUpdated);
            throw new NotImplementedException();
        }
    }
}
