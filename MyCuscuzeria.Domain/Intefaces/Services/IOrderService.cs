using MyCuscuzeria.Domain.Arguments.Order;

namespace MyCuscuzeria.Domain.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddOrderResponse AddOrder(AddOrderRequest request);
    }
}