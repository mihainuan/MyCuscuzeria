namespace MyCuscuzeria.Domain.Arguments.User
{
    public class AddUserResponse
    {
        public int UserId { get; set; }

        public AddUserResponse(int userid)
        {
            userid = UserId;
        }
    }
}