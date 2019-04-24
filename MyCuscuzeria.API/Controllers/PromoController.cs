using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Promo;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class PromoController : BaseController
    {
        private readonly IPromoService _promoService;

        public PromoController(IUnitOfWork unitofwork, IPromoService promoService) : base(unitofwork)
        {
            _promoService = promoService;
        }

        // GET
        [HttpGet]
        [Route("api/Promo/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var response = _promoService.GetAllPromos();
                return await ResponseAsync(response, _promoService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/Promo/Add")]
        public async Task<IActionResult> Add([FromBody] AddPromoRequest request)
        {
            try
            {
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

                var response = _promoService.AddPromo(request, Int32.MaxValue);
                return await ResponseAsync(response, _promoService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Promo/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int promoId)
        {
            try
            {
                var response = _promoService.RemovePromo(promoId);
                return await ResponseAsync(response, _promoService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }


    }
}