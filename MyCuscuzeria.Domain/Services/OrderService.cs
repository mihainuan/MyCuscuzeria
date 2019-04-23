using MyCuscuzeria.Domain.Arguments.Order;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Domain.Services
{
    public class OrderService : Notifiable, IOrderService
    {
        //Service Repository
        private readonly IOrderRepository _orderRepository;

        //Constructor using IoC (Injeção de Dependências)
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //TODO: Later...
        public Order GetOneOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OrderResponse> GetAllOrders()
        {
            IEnumerable<Order> orderCollection = _orderRepository.GetAllOrders();
            var response = orderCollection.ToList().Select(entity => (OrderResponse)entity);
            return response;
        }

        public OrderResponse AddOrder(AddOrderRequest request)
        {
            Order order = new Order(request.OrderStatus, request.OrderCreation, request.OrderTotal, request.Cuscuzeiro, request.User);
            AddNotifications(order);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                order = _orderRepository.AddOrder(order);
            }

            return (OrderResponse)order;
        }

        public Arguments.Base.Response RemoveOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}