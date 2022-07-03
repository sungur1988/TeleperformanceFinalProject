using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Features.StockUnits.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using MediatR;

namespace Application.Features.StockUnits.Handlers.Commands
{
    public class DeleteStockUnitCommandHandler : IRequestHandler<DeleteStockUnitCommand, BaseResponse>
    {
        private readonly IStockUnitReadRepository _stockUnitReadRepository;
        private readonly IStockUnitWriteRepository _stockUnitWriteRepository;
        private readonly IMapper _mapper;
        public DeleteStockUnitCommandHandler(IStockUnitReadRepository stockUnitReadRepository, IStockUnitWriteRepository stockUnitWriteRepository, IMapper mapper)
        {
            _stockUnitReadRepository = stockUnitReadRepository;
            _stockUnitWriteRepository = stockUnitWriteRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(DeleteStockUnitCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _stockUnitReadRepository.GetById(request.Id);
            if (entityToDelete==null)
            {
                return new BaseResponse(false, 404, Messages.StockUnitNotFound);
            }
            _stockUnitWriteRepository.Remove(entityToDelete);
            return new BaseResponse(true, 200, Messages.StockUnitDeleted);
        }
    }
}
