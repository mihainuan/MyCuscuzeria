using System;
using MyCuscuzeria.Domain.ValueObjects;

namespace Cuscuzeria.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public FullName Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastOrder { get; set; }
        public string UrlImg { get; set; }
        public virtual Order Order { get; set; }
    }
}
