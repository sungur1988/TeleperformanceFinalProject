using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Features.ShoppingLists.Requests.Commands;
using Application.Wrapper;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Commands
{
    public class ShoppingListCompletedCommandHandler : IRequestHandler<ShoppingListCompletedCommand, BaseResponse>
    {
        private readonly IShoppingListReadRepository _shoppingListReadRepository;
        private readonly IShoppingListWriteRepository _shoppingListWriteRepository;

        public ShoppingListCompletedCommandHandler(IShoppingListReadRepository shoppingListReadRepository, IShoppingListWriteRepository shoppingListWriteRepository)
        {
            _shoppingListReadRepository = shoppingListReadRepository;
            _shoppingListWriteRepository = shoppingListWriteRepository;
        }

        public async Task<BaseResponse> Handle(ShoppingListCompletedCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _shoppingListReadRepository.GetById(request.Id);
            if (entityToUpdate == null)
                return new BaseResponse(false, 404, Messages.ShoppingListNotFound);
            entityToUpdate.IsCompleted = request.IsCompleted;
            entityToUpdate.CompletedDate = DateTime.UtcNow;
            var updatedEntity=_shoppingListWriteRepository.Update(entityToUpdate);
            if (updatedEntity == null)
                return new BaseResponse(false, 500, Messages.InternalServerError);
            return new BaseResponse(true, 200, Messages.ShoppingListUpdated);
        }
    }
}
