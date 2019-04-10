using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int userid);

        User AuthUser(string email, string senha);

        void SaveUser(User user);

        bool Exists(string email);
    }
}