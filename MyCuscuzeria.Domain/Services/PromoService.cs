using MyCuscuzeria.Domain.Arguments.Promo;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public class PromoService : Notifiable, IPromoService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPromoRepository _promoRepository;

        public PromoService(IOrderRepository orderRepository, IPromoRepository promoRepository)
        {
            _orderRepository = orderRepository;
            _promoRepository = promoRepository;
        }

        public PromoResponse AddPromo(AddPromoRequest request, int orderId)
        {
            Order order = _orderRepository.GetOrder(orderId);

            Promo promo = new Promo(request.PromoTitle, request.Description, request.Active, order);

            AddNotifications(order);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                promo = _promoRepository.AddPromo(promo);
            }

            return (PromoResponse)promo;
        }

        public IEnumerable<PromoResponse> GetAllPromos()
        {
            throw new System.NotImplementedException();
        }

        public Promo GetOnePromo(int promoId)
        {
            throw new System.NotImplementedException();
        }

        public Arguments.Base.Response RemovePromo(int promoId)
        {
            throw new System.NotImplementedException();
        }
    }
}