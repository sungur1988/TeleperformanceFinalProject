using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Queries;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.ShoppingLists.Handlers.Queries
{
    public class GetShoppingListByIdQueryHandler : IRequestHandler<GetShoppingListByIdQuery, ServiceResponse<ShoppingListDto>>
    {
        private readonly IShoppingListReadRepository _shoppingListReadRepository;
        private readonly IMapper _mapper;

        public GetShoppingListByIdQueryHandler(IShoppingListReadRepository shoppingListReadRepository, IMapper mapper)
        {
            _shoppingListReadRepository = shoppingListReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ShoppingListDto>> Handle(GetShoppingListByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _shoppingListReadRepository.GetById(request.Id);
            if (result == null)
                return new ServiceResponse<ShoppingListDto>(default, false, 404, Messages.ShoppingListNotFound);
            return new ServiceResponse<ShoppingListDto>(_mapper.Map<ShoppingListDto>(result), true, 200);
        }
    }
}
