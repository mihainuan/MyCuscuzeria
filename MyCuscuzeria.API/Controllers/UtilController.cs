using Microsoft.AspNetCore.Mvc;
using System;

namespace MyCuscuzeria.API.Controllers
{
    public class UtilController
    {

        [HttpGet]
        [Route("")]
        public object Welcome()
        {
            return "Welcome to MyCuscuzeria!";
        }

        [HttpGet]
        [Route("api/version")]
        public object Version()
        {
            return new { Dev = "Mihai", Version = "0.0.1", Message = "Welcome to MyCuscuzeria!" };
        }

        [HttpGet]
        [Route("api/List/Users")]
        public object ListarUsuarios()
        {
            return new { User = "Mihai", CreatedAt = DateTime.Now.ToString() };
        }

        [HttpPost]
        [Route("api/post")]
        public object Post()
        {
            return "POST EXECUTED!";
        }

        [HttpPut]
        [Route("api/put")]
        public object Put()
        {
            return "PUT EXECUTED!";
        }

        [HttpDelete]
        [Route("api/delete")]
        public object Delete()
        {
            return "DELETE EXECUTED!";
        }




    }
}