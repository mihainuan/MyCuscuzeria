using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Accompaniment;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class AccompanimentController : BaseController
    {
        private readonly IAccompanimentService _accompanimentService;

        public AccompanimentController(IUnitOfWork unitofwork, IAccompanimentService accompanimentService) : base(unitofwork)
        {
            _accompanimentService = accompanimentService;
        }

        // GET
        [HttpGet]
        [Route("api/Accompaniments/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var response = _accompanimentService.GetAllAccompaniments();
                return await ResponseAsync(response, _accompanimentService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/Accompaniment/Add")]
        public async Task<IActionResult> Add([FromBody] AddAccompanimentRequest request)
        {
            try
            {
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

                var response = _accompanimentService.AddAccompaniment(request, Int32.MaxValue);
                return await ResponseAsync(response, _accompanimentService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Accompaniment/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int accompanimentId)
        {
            try
            {
                var response = _accompanimentService.RemoveAccompaniment(accompanimentId);
                return await ResponseAsync(response, _accompanimentService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}