using domain.Entities;
using Domain.Interfaces.Repositories;
using infra.Context;

namespace infra.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly Contexto _context;

        public UserRepository(Contexto context)
        {
            _context = context;
        }

        public User? GetByEmail(string email)
        {
            return (from i in _context.Users
                    where i.Email == email
                    select i).FirstOrDefault();
        }
    }
}