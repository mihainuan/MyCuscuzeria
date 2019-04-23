using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUnitOfWork unitofwork, IUserService userservice) : base(unitofwork)
        {
            _userService = userservice;
        }

        // GET
        [HttpGet]
        [Route("api/User/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var response = _userService.GetAllUsers();
                return await ResponseAsync(response, _userService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/User/Add")]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            try
            {
                var response = _userService.AddUser(request);
                return await ResponseAsync(response, _userService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/User/Delete/{id:UserId}")]
        public async Task<IActionResult> Delete(Guid userGuid)
        {
            try
            {
                var response = _userService.RemoveUser(userGuid);
                return await ResponseAsync(response, _userService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}