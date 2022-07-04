using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.ShoppingListItems.Requests;
using Application.Wrapper;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.ShoppingListItems.Handlers
{
    public class CreateShoppingListItemHandler : IRequestHandler<CreateShoppingListItemCommand, ServiceResponse<ShoppingListItemDto>>
    {
        private readonly IShoppingListItemWriteRepository _shoppingListItemWriteRepository;
        private readonly IStockUnitReadRepository _stockUnitReadRepository;
        private readonly IMapper _mapper;

        public CreateShoppingListItemHandler(IShoppingListItemWriteRepository shoppingListItemWriteRepository, IStockUnitReadRepository stockUnitReadRepository, IMapper mapper)
        {
            _shoppingListItemWriteRepository = shoppingListItemWriteRepository;
            _stockUnitReadRepository = stockUnitReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShoppingListItemDto>> Handle(CreateShoppingListItemCommand request, CancellationToken cancellationToken)
        {
            var stockUnitToAdd = await _stockUnitReadRepository.GetById(request.StockUnitId);
            if (stockUnitToAdd==null)
            {
                return new ServiceResponse<ShoppingListItemDto>(default, false, 404, Messages.CategoryNotFound);
            }
            var entityToAdd = _mapper.Map<ShoppingListItem>(request);
            entityToAdd.StockUnit = stockUnitToAdd;
            var result= await _shoppingListItemWriteRepository.AddAsync(entityToAdd);
            return new ServiceResponse<ShoppingListItemDto>(_mapper.Map<ShoppingListItemDto>(result), true, 204, Messages.ShoppingListItemCreated);
        }
    }
}
