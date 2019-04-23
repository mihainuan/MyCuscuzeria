using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Cuscuzeiro;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class CuscuzeiroController : BaseController
    {
        private readonly ICuscuzeiroService _cuscuzeiroService;

        public CuscuzeiroController(IUnitOfWork unitofwork, ICuscuzeiroService cuscuzeiroService) : base(unitofwork)
        {
            _cuscuzeiroService = cuscuzeiroService;
        }


        // GET
        [HttpGet]
        [Route("api/Cuscuzeiros/List")]
        public async Task<IActionResult> List()
        {
            try
            {
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
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

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
        [Route("api/Cuscuzeiro/Delete/{id:CuscuzeiroId}")]
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