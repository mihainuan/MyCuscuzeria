using Microsoft.AspNetCore.Mvc;
using MyCuscuzeria.API.Controllers.Base;
using MyCuscuzeria.Domain.Arguments.Order;
using MyCuscuzeria.Domain.Services;
using MyCuscuzeria.Infrastructure.Transactions;
using System;
using System.Threading.Tasks;

namespace MyCuscuzeria.API.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IUnitOfWork unitofwork, IOrderService orderService) : base(unitofwork)
        {
            _orderService = orderService;
        }


        // GET
        [HttpGet]
        [Route("api/Orders/List")]
        public async Task<IActionResult> List()
        {
            try
            {
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
                //string typeClaim = _httpContextAccessor.HttpContext.Type.FindFirst("Type").Value;
                //AddTypeResponse typeResponse = JsonConvert.DeserializeObject<AddTypeResponse>(); 

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