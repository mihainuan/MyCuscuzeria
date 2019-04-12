using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(int userid)
        {
            throw new System.NotImplementedException();
        }

        public User AuthUser(string email, string senha)
        {
            throw new System.NotImplementedException();
        }

        public void SaveUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}