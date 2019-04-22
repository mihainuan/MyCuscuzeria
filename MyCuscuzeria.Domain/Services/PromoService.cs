using MyCuscuzeria.Domain.Arguments.Promo;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Domain.Services
{
    public class PromoService : Notifiable, IPromoService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPromoRepository _promoRepository;

        //Constructor using IoT (Injeção de Dependências)
        public PromoService(IOrderRepository orderRepository, IPromoRepository promoRepository)
        {
            _orderRepository = orderRepository;
            _promoRepository = promoRepository;
        }

        //TODO: Later...
        public Promo GetOnePromo(int promoId)
        {
            throw new System.NotImplementedException();
        }

        //Section 2, Class 20 (22:08)
        public IEnumerable<PromoResponse> GetAllPromos()
        {
            IEnumerable<Promo> promoCollection = _promoRepository.GetAllPromo();
            var response = promoCollection.ToList().Select(entity => (PromoResponse)entity);
            return response;
        }

        public PromoResponse AddPromo(AddPromoRequest request, int orderId)
        {
            Order order = _orderRepository.GetOneOrder(orderId);

            Promo promo = new Promo(request.PromoTitle, request.Description, request.Active, order);

            AddNotifications(promo);

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

        public Arguments.Base.Response RemovePromo(int promoId)
        {
            //Verifica se existe uma Order vinculada antes de excluir a Promo
            bool existOrder = _promoRepository.ExistOrder(promoId);

            if (existOrder)
            {
                AddNotification("Promo", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Promoção", "Pedido"));
                return null;
            }

            Promo promo = _promoRepository.GetOnePromo(promoId);

            if (promo == null)
            {
                AddNotification("Promo", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (promo.Active)
            {
                AddNotification("Promo", "Não é possível excluir uma Promo ativa.");
                return null;
            }

            if (this.IsInvalid()) return null;

            _promoRepository.DeletePromo(promo);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        //Checks if Promo exists in ANY Order
        public bool ExistOrder(int promoId)
        {
            return _promoRepository.ExistOrder(promoId);
        }
    }
}