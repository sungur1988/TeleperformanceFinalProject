using Application.Constants;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Dtos;
using Application.Features.StockUnits.Requests.Commands;
using Application.Wrapper;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.StockUnits.Handlers.Commands
{
    public class CreateStockUnitCommandHandler : IRequestHandler<CreateStockUnitCommand, ServiceResponse<StockUnitDto>>
    {
        private readonly IStockUnitWriteRepository _stockUnitWriteRepository;
        private readonly IMapper _mapper;

        public CreateStockUnitCommandHandler(IStockUnitWriteRepository stockUnitWriteRepository, IMapper mapper)
        {
            _stockUnitWriteRepository = stockUnitWriteRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<StockUnitDto>> Handle(CreateStockUnitCommand request, CancellationToken cancellationToken)
        {
            var entityToAdd= _mapper.Map<StockUnit>(request);
            var result = await _stockUnitWriteRepository.AddAsync(entityToAdd);
            return new ServiceResponse<StockUnitDto>(_mapper.Map<StockUnitDto>(result), true,204,Messages.StockUnitCreated);
        }
    }
}
