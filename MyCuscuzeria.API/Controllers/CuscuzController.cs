using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Cuscuz;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class CuscuzController : BaseController
    {

        private readonly ICuscuzService _cuscuzService;

        public CuscuzController(IUnitOfWork unitofwork, ICuscuzService cuscuzService) : base(unitofwork)
        {
            _cuscuzService = cuscuzService;
        }


        // GET
        [HttpGet]
        [Route("api/Cuscuzs/List")]
        public async Task<IActionResult> List()
        {
            try
            {
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
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

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
        [Route("api/Cuscuz/Delete/{id:CuscuzId}")]
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