namespace Application.Persistence.IRepositories
{
    public interface IDatabaseRepository
    {
        Task<int> SaveChangesAsync();
    }
}