using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IDrinkRepository
    {
        Order GetOneOrder(int Orderid);

        IEnumerable<Order> GetAllOrder();

        Order AddOrder(Order Order);

        void DeleteOrder(Order Order);

        bool ExistOrder(int OrderId);
    }
}