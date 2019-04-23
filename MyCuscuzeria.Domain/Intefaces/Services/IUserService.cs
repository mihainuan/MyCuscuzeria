using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface IUserService : IServiceBase
    {
        /// <summary>
        /// Add/Save User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddUserResponse AddUser(AddUserRequest request);

        /// <summary>
        /// Authenticates User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AuthUserResponse AuthUser(AuthUserRequest request);

        /// <summary>
        /// Gets ALL Users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Gets ALL Users by GuID
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        IEnumerable<User> ListUsers(Guid userGuid);

        /// <summary>
        /// Gets ALL Users by Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        IEnumerable<User> ListUsers(string username);

        /// <summary>
        /// Deletes ONE User by GuID
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        Response RemoveUser(Guid userGuid);

    }
}