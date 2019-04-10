using MyCuscuzeria.Domain.Arguments.User;

namespace MyCuscuzeria.Domain.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Add/Save User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        AddUserResponse AddUser(AddUserRequest user);

        /// <summary>
        /// Authenticates User
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AuthUserResponse AuthUser(AuthUserRequest request);
    }
}