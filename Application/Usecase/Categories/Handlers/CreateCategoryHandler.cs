using Application.Common;
using Application.Persistence.IRepositories;
using Application.Usecase.Categories.Commands;
using Domain.Categories;

namespace Application.Usecase.Categories.Handlers
{
    public class CreateCategoryHandler : BaseHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repo;
        private readonly IDatabaseRepository _databaseRepository;

        public CreateCategoryHandler(ICategoryRepository repo, IDatabaseRepository databaseRepository)
        {
            _repo = repo;
            _databaseRepository = databaseRepository;
        }

        protected override async Task<Guid> HandleValidated(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                ID = Guid.NewGuid(),
                Name = command.Name,
                sortOrder = command.SortOrder,
                IsActive = command.IsActive
            };

            await _repo.AddAsync(category);
            await _databaseRepository.SaveChangesAsync();
            return category.ID;
        }
    }
}