using MyCuscuzeria.Domain.Arguments.Beverage;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;
using Response = MyCuscuzeria.Domain.Arguments.Base.Response;

namespace MyCuscuzeria.Domain.Services
{
    public class BeverageService : Notifiable, IBeverageService
    {
        //Service Repositories
        private readonly IOrderRepository _orderRepository;
        private readonly IBeverageRepository _beverageRepository;

        //Constructor using IoC (Injeção de Dependências)
        public BeverageService(IOrderRepository orderRepository, IBeverageRepository beverageRepository)
        {
            _orderRepository = orderRepository;
            _beverageRepository = beverageRepository;
        }

        //TODO: Later...
        public Beverage GetOneBeverage(int BeverageId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BeverageResponse> GetAllBeverages()
        {
            IEnumerable<Beverage> beverageCollection = _beverageRepository.GetAllBeverage();
            var response = beverageCollection.ToList().Select(entity => (BeverageResponse)entity);
            return response;
        }

        public BeverageResponse AddBeverage(AddBeverageRequest request, int orderId)
        {
            Order order = _orderRepository.GetOneOrder(orderId);

            Beverage beverage = new Beverage(request.BeverageName, order);

            AddNotifications(beverage);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                beverage = _beverageRepository.AddBeverage(beverage);
            }

            return (BeverageResponse)beverage;
        }

        public Response RemoveBeverage(int BeverageId)
        {
            //Verifica se existe uma Order vinculada antes de excluir a Drink
            bool existOrder = _beverageRepository.ExistOrder(BeverageId);

            if (existOrder)
            {
                AddNotification("Drink", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Bebida", "Pedido"));
                return null;
            }

            Beverage beverage = _beverageRepository.GetOneBeverage(BeverageId);

            if (beverage == null)
            {
                AddNotification("Cuscuz", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (this.IsInvalid()) return null;

            _beverageRepository.DeleteBeverage(beverage);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public bool ExistOrder(int BeverageId)
        {
            return _beverageRepository.ExistOrder(BeverageId);
        }
    }
}