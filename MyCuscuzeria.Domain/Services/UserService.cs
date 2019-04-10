using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Resources;
using MyCuscuzeria.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace MyCuscuzeria.Domain.Services
{
    public class UserService : Notifiable, IUserService
    {
        public AddUserResponse AddUser(AddUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AddUserRequest", MSG.OBJETO_X0_E_OBRIGATORIO.ToFormat("AddUserRequest"));
                return null;
            }

            //User to create
            FullName fullname = new FullName(request.Fullname.FirstName, request.Fullname.LastName);

            User user = new User();
            user.Fullname = fullname;
            user.Email = request.Email;
            user.Password = request.Password;
            user.CreatedAt = DateTime.Now;
            user.LastOrder = DateTime.Now.AddMonths(-7);
            user.Phone = request.Phone;
            user.Username = request.Username;

            if (user.Fullname.FirstName.Length < 3 || user.Fullname.FirstName.Length > 50)
            {
                throw new Exception("Primeiro Nome: Min: 3 | Max: 50");
            }
            if (user.Fullname.LastName.Length < 3 || user.Fullname.LastName.Length > 50)
            {
                throw new Exception("Último Nome: Min: 3 | Max: 50");
            }
            if (user.Email.IndexOf('@') < 1)
            {
                throw new Exception("E-mail Inválido!");
            }
            if (user.Password.Length < 3)
            {
                throw new Exception("Senha: Min: 3");
            }

            //Persists on DB
            //AddUserResponse response = new UserRepository().SaveUser(user);

            //return response;

            //TODO: Continue Notification Pattern Class (20:19)
            return new AddUserResponse(int.MinValue);
        }

        public AuthUserResponse AuthUser(AuthUserRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}