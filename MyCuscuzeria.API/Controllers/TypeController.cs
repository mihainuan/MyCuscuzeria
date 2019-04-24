using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Type;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class TypeController : BaseController
    {
        private readonly ITypeService _typeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TypeController(IUnitOfWork unitofwork, ITypeService typeService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _typeService = typeService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Type/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _typeService.GetAllTypes();
                return await ResponseAsync(response, _typeService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }


        // POST
        [HttpPost]
        [Route("api/Type/Add")]
        public async Task<IActionResult> Add([FromBody] AddTypeRequest request)
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _typeService.AddType(request, Int32.MaxValue);
                return await ResponseAsync(response, _typeService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Type/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int typeId)
        {
            try
            {
                var response = _typeService.RemoveType(typeId);
                return await ResponseAsync(response, _typeService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}