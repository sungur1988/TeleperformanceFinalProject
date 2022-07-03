using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Features.StockUnits.Requests.Commands;
using Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StockUnits.Handlers.Commands
{
    public class DeleteStockUnitCommandHandler : IRequestHandler<DeleteStockUnitCommand, BaseResponse>
    {
        private readonly IStockUnitReadRepository _stockUnitReadRepository;
        private readonly IStockUnitWriteRepository _stockUnitWriteRepository;


        public DeleteStockUnitCommandHandler(IStockUnitReadRepository stockUnitReadRepository, IStockUnitWriteRepository stockUnitWriteRepository)
        {
            _stockUnitReadRepository = stockUnitReadRepository;
            _stockUnitWriteRepository = stockUnitWriteRepository;
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
