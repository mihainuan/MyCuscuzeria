using MyCuscuzeria.Domain.Arguments.Cuscuzeiro;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Domain.Services
{
    public class CuscuzeiroService : Notifiable, ICuscuzeiroService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICuscuzeiroRepository _cuscuzeiroRepository;

        //Constructor using IoT (Injeção de Dependências)
        public CuscuzeiroService(IOrderRepository orderRepository, ICuscuzeiroRepository cuscuzeiroRepository)
        {
            _orderRepository = orderRepository;
            _cuscuzeiroRepository = cuscuzeiroRepository;
        }

        //TODO: Later...
        public Cuscuzeiro GetOneCuscuzeiro(int cuscuzeiroId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CuscuzeiroResponse> GetAllCuscuzeiros()
        {
            IEnumerable<Cuscuzeiro> cuscuzeiroCollection = _cuscuzeiroRepository.GetAllCuscuzeiro();
            var response = cuscuzeiroCollection.ToList().Select(entity => (CuscuzeiroResponse)entity);
            return response;
        }

        public CuscuzeiroResponse AddCuscuzeiro(AddCuscuzeiroRequest request, int orderId)
        {
            Order order = _orderRepository.GetOneOrder(orderId);

            Cuscuzeiro cuscuzeiro = new Cuscuzeiro(request.CuscuzeiroName, order);

            AddNotifications(cuscuzeiro);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                cuscuzeiro = _cuscuzeiroRepository.AddCuscuzeiro(cuscuzeiro);
            }

            return (CuscuzeiroResponse)cuscuzeiro;
        }

        public Arguments.Base.Response RemoveCuscuzeiro(int cuscuzeiroId)
        {
            //Verifica se existe uma Order vinculada antes de excluir a Drink
            bool existOrder = _cuscuzeiroRepository.ExistOrder(cuscuzeiroId);

            if (existOrder)
            {
                AddNotification("Drink", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Cuscuz", "Pedido"));
                return null;
            }

            Cuscuzeiro cuscuzeiro = _cuscuzeiroRepository.GetOneCuscuzeiro(cuscuzeiroId);

            if (cuscuzeiro == null)
            {
                AddNotification("Cuscuz", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (this.IsInvalid()) return null;

            _cuscuzeiroRepository.DeleteCuscuzeiro(cuscuzeiro);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        public bool ExistOrder(int cuscuzeiroId)
        {
            return _cuscuzeiroRepository.ExistOrder(cuscuzeiroId);
        }
    }
}