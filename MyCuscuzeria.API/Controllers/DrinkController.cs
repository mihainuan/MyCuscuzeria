using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Drink;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class DrinkController : BaseController
    {
        private readonly IDrinkService _drinkService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DrinkController(IUnitOfWork unitofwork, IDrinkService drinkService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _drinkService = drinkService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [AllowAnonymous]
        [Route("api/Drinks/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _drinkService.GetAllDrinks();
                return await ResponseAsync(response, _drinkService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/Drink/Add")]
        public async Task<IActionResult> Add([FromBody] AddDrinkRequest request)
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _drinkService.AddDrink(request, Int32.MaxValue);
                return await ResponseAsync(response, _drinkService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Drink/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int drinkId)
        {
            try
            {
                var response = _drinkService.RemoveDrink(drinkId);
                return await ResponseAsync(response, _drinkService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}