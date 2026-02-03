using Application.Common;
using Application.Exceptions;
using Application.Persistence.IRepositories;
using Application.Usecase.Categories.Commands;

namespace Application.Usecase.Categories.Handlers
{
    public class DeleteCategoryHandler : BaseHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _repo;
        private readonly IDatabaseRepository _databaseRepository;

        public DeleteCategoryHandler(ICategoryRepository repo, IDatabaseRepository databaseRepository)
        {
            _repo = repo;
            _databaseRepository = databaseRepository;
        }

        protected override async Task<bool> HandleValidated(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetByIdAsync(request.Id);
            if (category == null)
                throw new NotFoundException("Category not exist");

            _repo.Remove(category);
            await _databaseRepository.SaveChangesAsync();

            return true;
        }
    }
}