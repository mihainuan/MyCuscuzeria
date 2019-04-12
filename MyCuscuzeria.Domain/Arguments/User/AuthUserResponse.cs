namespace MyCuscuzeria.Domain.Arguments.User
{
    public class AuthUserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public static explicit operator AuthUserResponse(Entities.User entity)
        {
            return new AuthUserResponse()
            {
                UserId = entity.UserId,
                FirstName = entity.Fullname.FirstName
            };
        }

    }
}