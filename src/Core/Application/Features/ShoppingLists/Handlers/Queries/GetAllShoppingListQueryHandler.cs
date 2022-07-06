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
            try
            {
                var query = _shoppingListReadRepository.GetAll();
                if (!string.IsNullOrWhiteSpace(request.Keyword))
                {
                    query = query.Where(x => x.Name.Contains(request.Keyword) || x.Category.Name.Contains(request.Keyword));
                }
                var result = query
                    .Include(x => x.Category)
                    .Include(x => x.ShoppingListItems).ToList();
                if (result.Count() == 0)
                {
                    return Task.FromResult(new ServiceResponse<IEnumerable<ShoppingListDto>>(default, false, 404, Messages.ShoppingListNotFound));
                }
                return Task.FromResult(new ServiceResponse<IEnumerable<ShoppingListDto>>(_mapper.Map<IEnumerable<ShoppingListDto>>(result), true, 200));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
