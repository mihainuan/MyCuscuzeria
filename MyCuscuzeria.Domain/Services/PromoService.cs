using MyCuscuzeria.Domain.Arguments.Promo;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
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
            Order order = _orderRepository.GetOneOrder(orderId);

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
            //TODO: To be continued...
            //bool existOrderAttached = _
            var existOrder = _promoRepository.GetOnePromo(promoId);

            var promo = _promoRepository.GetOnePromo(promoId);

            if (promo == null) return null;

            if (promo.Active)
            {
                AddNotification("Promo", "Não é possível excluir uma Promo ativa.");
            }

            _promoRepository.DeletePromo(promo);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public bool ExistOrder(int promoId)
        {
            return _orderRepository.ExistingPromo(promoId);
        }
    }
}