using MyCuscuzeria.Domain.Arguments.Cuscuz;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Domain.Services
{
    public class CuscuzService : Notifiable, ICuscuzService
    {
        //Service Repositories
        private readonly IOrderRepository _orderRepository;
        private readonly ICuscuzRepository _cuscuzRepository;

        //Constructor using IoC (Injeção de Dependências)
        public CuscuzService(IOrderRepository orderRepository, ICuscuzRepository cuscuzRepository)
        {
            _orderRepository = orderRepository;
            _cuscuzRepository = cuscuzRepository;
        }

        //TODO: Later...
        public Cuscuz GetOneCuscuz(int cuscuzId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CuscuzResponse> GetAllCuscuzes()
        {
            IEnumerable<Cuscuz> cuscuzCollection = _cuscuzRepository.GetAllCuscuz();
            var response = cuscuzCollection.ToList().Select(entity => (CuscuzResponse)entity);
            return response;
        }

        public CuscuzResponse AddCuscuz(AddCuscuzRequest request, int orderId)
        {
            Order order = _orderRepository.GetOneOrder(orderId);

            Cuscuz cuscuz = new Cuscuz(request.CuscuzName, request.Description, order);

            AddNotifications(cuscuz);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                cuscuz = _cuscuzRepository.AddCuscuz(cuscuz);
            }

            return (CuscuzResponse)cuscuz;
        }

        public Arguments.Base.Response RemoveCuscuz(int cuscuzId)
        {
            //Verifica se existe uma Order vinculada antes de excluir a Drink
            bool existOrder = _cuscuzRepository.ExistOrder(cuscuzId);

            if (existOrder)
            {
                AddNotification("Drink", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Cuscuz", "Pedido"));
                return null;
            }

            Cuscuz cuscuz = _cuscuzRepository.GetOneCuscuz(cuscuzId);

            if (cuscuz == null)
            {
                AddNotification("Cuscuz", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (this.IsInvalid()) return null;

            _cuscuzRepository.DeleteCuscuz(cuscuz);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public bool ExistOrder(int cuscuzId)
        {
            return _cuscuzRepository.ExistOrder(cuscuzId);
        }
    }
}