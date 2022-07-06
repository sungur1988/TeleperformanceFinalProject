using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Dtos;
using Application.Features.ShoppingLists.Requests.Queries;
using Application.Wrapper;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

        public  Task<ServiceResponse<ShoppingListDto>> Handle(GetShoppingListByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _shoppingListReadRepository.GetAll(x => x.Id == request.Id).Include(x => x.Category).Include(x => x.ShoppingListItems).ToList()[0];
                if (result == null)
                    return Task.FromResult(new ServiceResponse<ShoppingListDto>(default, false, 404, Messages.ShoppingListNotFound));
                return Task.FromResult(new ServiceResponse<ShoppingListDto>(_mapper.Map<ShoppingListDto>(result), true, 200));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
