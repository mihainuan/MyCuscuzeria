using MyCuscuzeria.Domain.Arguments.Order;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface IOrderService : IServiceBase
    {
        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddOrderResponse AddOrder(AddOrderRequest request);
    }
}