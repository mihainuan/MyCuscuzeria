using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IOrderRepository
    {
        Order GetOneOrder(int orderId);

        IEnumerable<Order> GetAllOrders();

        Order AddOrder(Order promo);

        void DeleteOrder(Order promo);

        bool ExistingPromo(int promoId);

    }
}