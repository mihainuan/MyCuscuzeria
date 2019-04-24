using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.API.Security;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUnitOfWork unitofwork, IUserService userService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [Route("api/User/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

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
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _userService.AddUser(request);
                return await ResponseAsync(response, _userService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/User/Auth")]
        public object Auth(
            [FromBody] AuthUserRequest request,
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)
        {
            bool validCredentials = false;
            AuthUserResponse response = _userService.AuthUser(request);

            validCredentials = response != null;

            if (validCredentials)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(response.UserId.ToString(), "UserId"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Int16.MaxValue.ToString("N")),
                        new Claim("User",JsonConvert.SerializeObject(response))
                    });

                DateTime creationDate = DateTime.Now;
                DateTime expirationDate = creationDate + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = creationDate,
                    Expires = expirationDate
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    userFirstName = response.FirstName
                };
            }
            else
            {
                return new
                {
                    authenticated = true,
                    _userService.Notifications
                };
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/User/Delete/{id:Guid}")]
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