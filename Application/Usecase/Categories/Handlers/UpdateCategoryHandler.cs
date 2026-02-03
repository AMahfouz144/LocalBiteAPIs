using Application.Common;
using Application.Persistence.IRepositories;
using Application.Usecase.Categories.Commands;

public class UpdateCategoryHandler :BaseHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _repo;
    private readonly IDatabaseRepository _databaseRepository;

    public UpdateCategoryHandler(ICategoryRepository repo, IDatabaseRepository databaseRepository)
    {
        _repo = repo;
        _databaseRepository = databaseRepository;
    }

    protected override async Task<bool> HandleValidated(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var dto = request;

        var category = await _repo.GetByIdAsync(dto.Id);
        if (category == null)
            throw new ApplicationException("Category not found");

        category.Name = dto.Name;
        category.sortOrder = dto.SortOrder;
        category.IsActive = dto.IsActive;

        await _repo.UpdateAsync(category);
        await _databaseRepository.SaveChangesAsync();

        return true;
    }
}