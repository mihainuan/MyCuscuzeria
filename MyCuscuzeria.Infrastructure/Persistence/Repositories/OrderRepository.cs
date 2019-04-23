using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        //Database context
        private readonly MyCuscuzeriaContext _context;

        //Constructor using IoC (Injeção de Dependências)
        public OrderRepository(MyCuscuzeriaContext context)
        {
            _context = context;
        }

        public Order GetOneOrder(int orderId)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            //TODO: Review later
            return _context.Orders.ToList();
        }

        public Order AddOrder(Order order)
        {
            _context.Orders.Add(order);
            return order;
        }

        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
        }
    }
}