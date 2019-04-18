using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Arguments.Order;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface IOrderService : IServiceBase
    {

        /// <summary>
        /// List ONE specific Order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOneOrder(int orderId);

        /// <summary>
        /// List ALL Orders
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderResponse> GetAllOrders();

        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddOrderResponse AddOrder(AddOrderRequest request);

        /// <summary>
        /// Deletes ONE specific Promo
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Response RemoveOrder(int orderId);
    }
}