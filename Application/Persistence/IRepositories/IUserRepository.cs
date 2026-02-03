using Domain.Users;

namespace Application.Persistence.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        //IsAuthenticated
        Task<User> IsAuthenticated();
    }
}
