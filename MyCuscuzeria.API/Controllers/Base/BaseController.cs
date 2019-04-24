using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MyCuscuzeria.Domain.Services.Base;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private IServiceBase _serviceBase;
        private IUnitOfWork unitofwork;

        public BaseController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IActionResult> ResponseAsync(object result, IServiceBase serviceBase)
        {
            _serviceBase = serviceBase;

            if (!serviceBase.Notifications.Any())
            {
                try
                {
                    _unitofwork.Commit();

                    return Ok(result);
                    //return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (Exception)
                {
                    //Error
                    return BadRequest($"Houve um problema interno com o Servidor.");
                    //Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o Servidor.")
                }
            }
            else
            {
                return BadRequest(new { errors = serviceBase.Notifications });
                //Request.CreateResponse(HttpStatusCode.Conflict, new { errors = serviceBase.Notifications })
            }
        }

        public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
        {
            return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
        }

        protected override void Dispose(bool disposing)
        {
            //Dispose cleans notifications
            if (_serviceBase != null)
            {
                _serviceBase.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}