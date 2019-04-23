using MyCuscuzeria.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int userid);

        User AuthUser(string email, string senha);

        void SaveUser(User user);

        bool Exists(string email);

        IEnumerable<User> ListUsers(Guid userGuid);

        IEnumerable<User> ListUsers(string username);
    }
}