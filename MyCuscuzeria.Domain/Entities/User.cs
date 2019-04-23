using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Extensions;
using MyCuscuzeria.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;

namespace MyCuscuzeria.Domain.Entities
{
    public class User : EntityBase
    {
        public User(int userId, string username, FullName fullname, string password, string email, string phone, DateTime createdAt, DateTime? lastOrder, string urlImg, Order order)
        {
            UserId = userId;
            Username = username;
            Fullname = fullname;
            Password = password;
            Email = email;
            Phone = phone;
            CreatedAt = DateTime.Now;
            LastOrder = DateTime.Now.AddMonths(-9);
            UrlImg = urlImg;
            Order = order;

            new AddNotifications<User>(this).IfNullOrInvalidLength(x => x.Password, 3, 32);

            //Cypher password
            Password = Password.ConvertToMD5();

            AddNotifications(fullname);
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;

            new AddNotifications<User>(this).IfNullOrInvalidLength(x => x.Password, 3, 32);

            //Cypher password
            Password = Password.ConvertToMD5();
        }

        //PK
        public int UserId { get; private set; }

        public string Username { get; private set; }
        public FullName Fullname { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastOrder { get; private set; }
        public string UrlImg { get; private set; }

        public virtual Order Order { get; private set; }


    }
}
