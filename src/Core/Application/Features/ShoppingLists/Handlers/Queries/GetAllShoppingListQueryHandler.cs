using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Queries;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Queries
{
    public class GetAllShoppingListQueryHandler : IRequestHandler<GetAllShoppingListQuery, ServiceResponse<IEnumerable<ShoppingListDto>>>
    {
        private readonly IShoppingListReadRepository _shoppingListReadRepository;
        private readonly IMapper _mapper;

        public GetAllShoppingListQueryHandler(IShoppingListReadRepository shoppingListReadRepository, IMapper mapper)
        {
            _shoppingListReadRepository = shoppingListReadRepository;
            _mapper = mapper;
        }

        public Task<ServiceResponse<IEnumerable<ShoppingListDto>>> Handle(GetAllShoppingListQuery request, CancellationToken cancellationToken)
        {
             var result = _shoppingListReadRepository
                    .GetAll()
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize).AsEnumerable();
            if (result.Count() == 0)
            {
                return Task.FromResult(new ServiceResponse<IEnumerable<ShoppingListDto>>(default, false, 404, Messages.ShoppingListNotFound));
            }
            return Task.FromResult(new ServiceResponse<IEnumerable<ShoppingListDto>>(_mapper.Map<IEnumerable<ShoppingListDto>>(result), true, 200));
        }
    }
}
