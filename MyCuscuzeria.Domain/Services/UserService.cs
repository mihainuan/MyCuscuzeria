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

            fullname.FirstName = "Mihai";
            fullname.LastName = "Silva";

            User user = new User();

            user.Fullname = fullname;
            user.Email = request.Email;
            user.Password = request.Password;
            user.CreatedAt = DateTime.Now;
            user.LastOrder = DateTime.Now.AddMonths(-7);
            user.Phone = request.Phone;
            user.Username = request.Username;
            user.GuId = Guid.NewGuid();

            AddNotifications(fullname, user);

            //Persists on DB
            //AddUserResponse response = new UserRepository().SaveUser(user);
            //return response;

            if (this.IsInvalid() == true)
            {
                return null;
            }

            //TODO: Continue Notification Pattern Class (20:19)
            return new AddUserResponse(int.MaxValue, Guid.NewGuid());
        }

        public AuthUserResponse AuthUser(AuthUserRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}