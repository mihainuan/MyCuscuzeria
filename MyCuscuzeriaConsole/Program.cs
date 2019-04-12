using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Extensions;
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
                Password = "p@ssw0rd".ConvertToMD5()
            };
            //TODO: Corrigir Later
            //var response = new UserService().AddUser(request);

            //Console.WriteLine("(RESPONSE) GuID: " + request.GuId);

            Console.WriteLine("(REQUEST) UserId: " + request.UserId);
            Console.WriteLine("(REQUEST) FirstName: " + request.Fullname.FirstName);
            Console.WriteLine("(REQUEST) LastName: " + request.Fullname.LastName);
            Console.WriteLine("(REQUEST) Password: " + request.Password);
            Console.WriteLine("(REQUEST) CreatedAt: " + request.CreatedAt);
            Console.WriteLine("(REQUEST) Email: " + request.Email);
            Console.WriteLine("(REQUEST) LastOrder: " + request.LastOrder);
            Console.WriteLine("(REQUEST) Phone: " + request.Phone);
            Console.WriteLine("(REQUEST) Username: " + request.Username);

            Console.ReadKey();

        }
    }
}
