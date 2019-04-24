using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Order;
using MyCuscuzeria.Domain.Arguments.User;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderController(IUnitOfWork unitofwork, IOrderService orderService, IHttpContextAccessor httpContextAccessor) : base(unitofwork)
        {
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET
        [HttpGet]
        [Route("api/Orders/List")]
        public async Task<IActionResult> List()
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _orderService.GetAllOrders();
                return await ResponseAsync(response, _orderService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        // POST
        [HttpPost]
        [Route("api/Order/Add")]
        public async Task<IActionResult> Add([FromBody] AddOrderRequest request)
        {
            try
            {
                string userClaim = _httpContextAccessor.HttpContext.User.FindFirst("User").Value;
                AddUserResponse userResponse = JsonConvert.DeserializeObject<AddUserResponse>(userClaim);

                var response = _orderService.AddOrder(request);
                return await ResponseAsync(response, _orderService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/Order/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            try
            {
                var response = _orderService.RemoveOrder(orderId);
                return await ResponseAsync(response, _orderService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}