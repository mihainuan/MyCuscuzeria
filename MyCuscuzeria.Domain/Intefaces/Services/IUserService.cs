using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services.Base;

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
    }
}