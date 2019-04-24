using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Cuscuzeiro;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class CuscuzeiroController : BaseController
    {
        private readonly ICuscuzeiroService _cuscuzeiroService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CuscuzeiroController(IUnitOfWork unitofwork, ICuscuzeiroService cuscuzeiroService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _cuscuzeiroService = cuscuzeiroService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Cuscuzeiros/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _cuscuzeiroService.GetAllCuscuzeiros();
                return await ResponseAsync(response, _cuscuzeiroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/Cuscuzeiro/Add")]
        public async Task<IActionResult> Add([FromBody] AddCuscuzeiroRequest request)
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _cuscuzeiroService.AddCuscuzeiro(request, Int32.MaxValue);
                return await ResponseAsync(response, _cuscuzeiroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Cuscuzeiro/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int cuscuzeiroId)
        {
            try
            {
                var response = _cuscuzeiroService.RemoveCuscuzeiro(cuscuzeiroId);
                return await ResponseAsync(response, _cuscuzeiroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}