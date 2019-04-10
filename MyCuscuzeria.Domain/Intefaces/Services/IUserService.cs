using MyCuscuzeria.Domain.Arguments.User;

namespace MyCuscuzeria.Domain.Services
{
    public interface IUserService
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