using Microsoft.EntityFrameworkCore;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        public UserRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public User GetUser(int userid)
        {
            return _cuscuzeriaContext.Users.FirstOrDefault(x => x.UserId == userid);
        }

        public User AuthUser(string email, string senha)
        {
            return _cuscuzeriaContext.Users.FirstOrDefault(x => x.Email == email && x.Password == senha);
        }

        public void SaveUser(User user)
        {
            _cuscuzeriaContext.Add(user);
        }

        public bool Exists(string email)
        {
            return _cuscuzeriaContext.Users.Any(x => x.Email == email);
        }

        public IEnumerable<User> ListUsers(Guid userGuid)
        {
            return _cuscuzeriaContext.Users.Include(x => x.Order).Where(x => x.GuId == userGuid).ToList();
        }

        public IEnumerable<User> ListUsers(string username)
        {
            var query = _cuscuzeriaContext.Users.Include(x => x.Order).AsQueryable();

            username.Split(' ').ToList().ForEach(user =>
                {
                    query = query.Where(x => x.Username.Contains(user));
                });

            return query.ToList();
        }
    }
}