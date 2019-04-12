using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Domain.ValueObjects;
using System;

namespace MyCuscuzeriaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AddUserRequest request = new AddUserRequest()
            {
                Fullname = new FullName("0", "0"),
                Email = "email@noreply.com",
                CreatedAt = DateTime.Now,
                LastOrder = DateTime.Now.AddMonths(-9),
                Phone = "+1 (509) 339-4207",
                Username = "test_user",
                Password = "p@ssw0rd"
            };

            var response = new UserService().AddUser(request);


            Console.WriteLine("(REQUEST) FirstName: " + request.Fullname.FirstName);
            Console.WriteLine("(RESPONSE) GuID: " + response.GuId);

            Console.ReadKey();

        }
    }
}
