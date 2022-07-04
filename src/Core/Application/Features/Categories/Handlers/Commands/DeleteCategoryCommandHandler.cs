using Application.Constants;
using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Application.Features.Categories.Requests.Commands;
using Application.Wrapper;
using MediatR;

namespace Application.Features.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<BaseResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _categoryReadRepository.GetById(request.Id);
            if (entityToDelete==null)
            {
                return new BaseResponse(false,404,Messages.CategoryNotFound);
            }
            _categoryWriteRepository.Remove(entityToDelete);
            return new BaseResponse(true, 200, Messages.CategoryDeleted);
        }
    }
}
