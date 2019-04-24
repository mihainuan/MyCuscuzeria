using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;

namespace MyCuscuzeria.Domain.Entities
{
    public class Drink : EntityBase
    {
        //PK
        public int DrinkId { get; private set; }

        public string DrinkName { get; private set; }
        public string Description { get; private set; }

        public int OrderId { get; private set; }
        public virtual Order Order { get; private set; }

        public Drink(string drinkname, string description, Order order)
        {
            DrinkName = drinkname;
            Description = description;
            Order = order;

            new AddNotifications<Drink>(this).IfNullOrInvalidLength(x => x.DrinkName, 2, 100,
                    MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES)
                .IfNullOrInvalidLength(x => x.Description, 10, 200,
                    MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);

            AddNotifications(order);
        }

        protected Drink()
        {

        }
    }
}
