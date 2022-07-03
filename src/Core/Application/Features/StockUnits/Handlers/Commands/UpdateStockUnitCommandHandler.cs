using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.StockUnits.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.StockUnits.Handlers.Commands
{
    public class UpdateStockUnitCommandHandler : IRequestHandler<UpdateStockUnitCommand, ServiceResponse<StockUnitDto>>
    {
        private readonly IStockUnitWriteRepository _stockUnitWriteRepository;
        private readonly IStockUnitReadRepository _stockUnitReadRepository;
        private readonly IMapper _mapper;

        public UpdateStockUnitCommandHandler(IStockUnitWriteRepository stockUnitWriteRepository, IStockUnitReadRepository stockUnitReadRepository, IMapper mapper)
        {
            _stockUnitWriteRepository = stockUnitWriteRepository;
            _stockUnitReadRepository = stockUnitReadRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<StockUnitDto>> Handle(UpdateStockUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _stockUnitReadRepository.GetById(request.Id);
            if (unit == null)
            {
                return new ServiceResponse<StockUnitDto>(default, false, 404, Messages.StockUnitNotFound);
            }
            var entityToUpdated = _mapper.Map(request, unit);
            var result = _stockUnitWriteRepository.Update(entityToUpdated);
            if (result ==null)
            {
                return new ServiceResponse<StockUnitDto>(default, false, 500, Messages.InternalServerError);
            }
            return new ServiceResponse<StockUnitDto>(_mapper.Map<StockUnitDto>(result), true, 200, Messages.StockUnitUpdated);
        }
    }
}
