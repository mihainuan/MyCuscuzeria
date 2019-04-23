using MyCuscuzeria.Domain.Arguments.Drink;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Domain.Services
{
    public class DrinkService : Notifiable, IDrinkService
    {
        //Service Repositories
        private readonly IOrderRepository _orderRepository;
        private readonly IDrinkRepository _drinkRepository;

        //Constructor using IoC (Injeção de Dependências)
        public DrinkService(IOrderRepository orderRepository, IDrinkRepository drinkRepository)
        {
            _orderRepository = orderRepository;
            _drinkRepository = drinkRepository;
        }

        //TODO: Later...
        public Drink GetOneDrink(int DrinkId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DrinkResponse> GetAllDrinks()
        {
            IEnumerable<Drink> drinkCollection = _drinkRepository.GetAllDrink();
            var response = drinkCollection.ToList().Select(entity => (DrinkResponse)entity);
            return response;
        }

        public DrinkResponse AddDrink(AddDrinkRequest request, int orderId)
        {
            Order order = _orderRepository.GetOneOrder(orderId);

            Drink drink = new Drink(request.DrinkName, request.Description, order);

            AddNotifications(drink);

            if (this.IsInvalid())
            {
                return null;
            }
            else
            {
                drink = _drinkRepository.AddDrink(drink);
            }

            return (DrinkResponse)drink;
        }

        public Arguments.Base.Response RemoveDrink(int DrinkId)
        {
            //Verifica se existe uma Order vinculada antes de excluir a Drink
            bool existOrder = _drinkRepository.ExistOrder(DrinkId);

            if (existOrder)
            {
                AddNotification("Drink", MSG.NAO_E_POSSIVEL_EXCLUIR_UMA_X0_ASSOCIADA_A_UMA_X1.ToFormat("Bebida", "Pedido"));
                return null;
            }

            Drink drink = _drinkRepository.GetOneDrink(DrinkId);

            if (drink == null)
            {
                AddNotification("Drink", MSG.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (this.IsInvalid()) return null;

            _drinkRepository.DeleteDrink(drink);

            return new Arguments.Base.Response() { Message = MSG.OPERACAO_REALIZADA_COM_SUCESSO };
        }

        //Checks if Drink exists in ANY Order
        public bool ExistOrder(int DrinkId)
        {
            return _drinkRepository.ExistOrder(DrinkId);
        }
    }
}