using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace MyCuscuzeria.Domain.Services
{
    public class UserService : Notifiable, IUserService
    {
        //Service Repositories
        private readonly IUserRepository _userRepository;

        //Constructor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AddUserRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AddUserRequest"));
                return null;
            }

            User user = new User(
                request.UserId,
                request.Username,
                request.Fullname,
                request.Password,
                request.Email,
                request.Phone,
                request.CreatedAt,
                request.LastOrder,
                request.UrlImg,
                request.Order
                );

            AddNotifications(user);

            if (this.IsInvalid() == true)
            {
                return null;
            }

            //Persists on DB
            _userRepository.SaveUser(user);
            return new AddUserResponse(user.UserId, user.GuId);
        }

        public AuthUserResponse AuthUser(AuthUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AuthUserRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AuthUserRequest"));
                return null;
            }

            var user = new User(request.Email, request.Password);

            AddNotifications(user);

            if (this.IsInvalid() == true)
            {
                return null;
            }

            //Auths on DB
            user = _userRepository.AuthUser(user.Email, user.Password);

            if (user == null)
            {
                AddNotification("User", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            //Explicit conversion
            var response = (AuthUserResponse)user;

            return response;
        }
    }
}