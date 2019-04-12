using System;

namespace MyCuscuzeria.Domain.Arguments.User
{
    public class AddUserResponse
    {
        public int UserId { get; set; }
        public virtual Guid GuId { get; set; }

        public AddUserResponse(int userid, Guid guid)
        {
            UserId = userid;
            GuId = guid;
        }
    }
}