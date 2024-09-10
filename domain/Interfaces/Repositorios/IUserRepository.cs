using domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User? GetByEmail(string email);
    }
}