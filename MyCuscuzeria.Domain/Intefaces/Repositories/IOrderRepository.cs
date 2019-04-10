using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderid);

        void SaveOrder(Order order);
    }
}