using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Cuscuz;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class CuscuzController : BaseController
    {

        private readonly ICuscuzService _cuscuzService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CuscuzController(IUnitOfWork unitofwork, ICuscuzService cuscuzService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _cuscuzService = cuscuzService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cuscuzs/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _cuscuzService.GetAllCuscuzes();
                return await ResponseAsync(response, _cuscuzService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/Cuscuz/Add")]
        public async Task<IActionResult> Add([FromBody] AddCuscuzRequest request)
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _cuscuzService.AddCuscuz(request, Int32.MaxValue);
                return await ResponseAsync(response, _cuscuzService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Cuscuz/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int cuscuzId)
        {
            try
            {
                var response = _cuscuzService.RemoveCuscuz(cuscuzId);
                return await ResponseAsync(response, _cuscuzService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}