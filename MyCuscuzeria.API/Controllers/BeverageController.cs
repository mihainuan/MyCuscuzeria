using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Beverage;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class BeverageController : BaseController
    {
        private readonly IBeverageService _beverageService;

        public BeverageController(IUnitOfWork unitofwork, IBeverageService beverageService) : base(unitofwork)
        {
            _beverageService = beverageService;
        }


        // GET
        [HttpGet]
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
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

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
        [Route("api/Beverage/Delete/{id:BeverageId}")]
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