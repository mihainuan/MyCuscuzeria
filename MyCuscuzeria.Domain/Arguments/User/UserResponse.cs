using MyCuscuzeria.Domain.ValueObjects;
using System;

namespace MyCuscuzeria.Domain.Arguments.Type
{
    public class UserResponse
    {
        public int UserId { get; private set; }

        public string Username { get; private set; }
        public FullName Fullname { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastOrder { get; private set; }
        public string UrlImg { get; private set; }

        public virtual Entities.Order Order { get; private set; }

        public static explicit operator UserResponse(Entities.User entity)
        {
            return new UserResponse()
            {
                UserId = entity.UserId,
                Username = entity.Username,
                Fullname = entity.Fullname,
                Password = entity.Password,
                Email = entity.Email,
                Phone = entity.Phone,
                CreatedAt = entity.CreatedAt,
                LastOrder = entity.LastOrder,
                UrlImg = entity.UrlImg,
                Order = entity.Order
            };
        }
    }
}