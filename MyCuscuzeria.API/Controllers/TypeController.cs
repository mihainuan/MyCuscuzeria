using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Type;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class TypeController : BaseController
    {
        private readonly ITypeService _typeService;

        public TypeController(IUnitOfWork unitofwork, ITypeService typeService) : base(unitofwork)
        {
            _typeService = typeService;
        }

        // GET
        [HttpGet]
        [Route("api/Type/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                var response = _typeService.GetAllTypes();
                return await ResponseAsync(response, _typeService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }


        // POST
        [HttpPost]
        [Route("api/Type/Add")]
        public async Task<IActionResult> Add([FromBody] AddTypeRequest request)
        {
            try
            {
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

                var response = _typeService.AddType(request, Int32.MaxValue);
                return await ResponseAsync(response, _typeService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Type/Delete/{id:TypeId}")]
        public async Task<IActionResult> Delete(int typeId)
        {
            try
            {
                var response = _typeService.RemoveType(typeId);
                return await ResponseAsync(response, _typeService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}