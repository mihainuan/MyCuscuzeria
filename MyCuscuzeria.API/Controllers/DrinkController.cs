using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Drink;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class DrinkController : BaseController
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IUnitOfWork unitofwork, IDrinkService drinkService) : base(unitofwork)
        {
            _drinkService = drinkService;
        }


        // GET
        [HttpGet]
        [Route("api/Drinks/List")]
        public async Task<IActionResult> List()
        {
            try
            {
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
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

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
        [Route("api/Drink/Delete/{id:DrinkId}")]
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