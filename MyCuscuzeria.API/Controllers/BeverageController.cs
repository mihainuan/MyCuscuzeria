using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Beverage;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class BeverageController : BaseController
    {
        private readonly IBeverageService _beverageService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BeverageController(IUnitOfWork unitofwork, IBeverageService beverageService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _beverageService = beverageService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Beverages/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var response = _beverageService.GetAllBeverages();
                return await ResponseAsync(response, _beverageService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/Beverage/Add")]
        public async Task<IActionResult> Add([FromBody] AddBeverageRequest request)
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _beverageService.AddBeverage(request, Int32.MaxValue);
                return await ResponseAsync(response, _beverageService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Beverage/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int BeverageId)
        {
            try
            {
                var response = _beverageService.RemoveBeverage(BeverageId);
                return await ResponseAsync(response, _beverageService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}