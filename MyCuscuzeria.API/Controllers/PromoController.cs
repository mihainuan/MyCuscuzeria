using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Promo;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class PromoController : BaseController
    {
        private readonly IPromoService _promoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PromoController(IUnitOfWork unitofwork, IPromoService promoService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _promoService = promoService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [Route("api/Promo/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

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
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

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