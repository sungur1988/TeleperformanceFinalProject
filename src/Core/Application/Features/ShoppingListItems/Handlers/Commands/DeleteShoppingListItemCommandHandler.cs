using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Features.ShoppingListItems.Requests.Commands;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingListItems.Handlers.Commands
{
    public class DeleteShoppingListItemCommandHandler : IRequestHandler<DeleteShoppingListItemCommand, BaseResponse>
    {
        private readonly IShoppingListItemReadRepository _shoppingListItemReadRepository;
        private readonly IShoppingListItemWriteRepository _shoppingListItemWriteRepository;

        public DeleteShoppingListItemCommandHandler(IShoppingListItemReadRepository shoppingListItemReadRepository, IShoppingListItemWriteRepository shoppingListItemWriteRepository)
        {
            _shoppingListItemReadRepository = shoppingListItemReadRepository;
            _shoppingListItemWriteRepository = shoppingListItemWriteRepository;
        }

        public async Task<BaseResponse> Handle(DeleteShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _shoppingListItemReadRepository.GetById(request.Id);
            if (entityToDelete == null)
            {
                return new BaseResponse(false, 404, Messages.ShoppingListItemNotFound);
            }
            _shoppingListItemWriteRepository.Remove(entityToDelete);
            return new BaseResponse(true, 200, Messages.ShoppingListItemDeleted);
        }
    }
}
