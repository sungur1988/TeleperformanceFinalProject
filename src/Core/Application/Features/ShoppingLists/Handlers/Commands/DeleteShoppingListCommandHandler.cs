using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Commands
{
    public class DeleteShoppingListCommandHandler : IRequestHandler<DeleteShoppingListCommand, BaseResponse>
    {
        private readonly IShoppingListReadRepository _shoppingListReadRepository;
        private readonly IShoppingListWriteRepository _shoppingListWriteRepository;

        public DeleteShoppingListCommandHandler(IShoppingListReadRepository shoppingListReadRepository, IShoppingListWriteRepository shoppingListWriteRepository)
        {
            _shoppingListReadRepository = shoppingListReadRepository;
            _shoppingListWriteRepository = shoppingListWriteRepository;
        }

        public async Task<BaseResponse> Handle(DeleteShoppingListCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _shoppingListReadRepository.GetById(request.Id);
            if (entityToDelete == null)
                return new BaseResponse(false, 404, Messages.ShoppingListNotFound);
            _shoppingListWriteRepository.Remove(entityToDelete);
            return new BaseResponse(true, 200, Messages.ShoppingListDeleted);
        }
    }
}
