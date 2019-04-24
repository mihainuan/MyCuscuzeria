using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;

namespace MyCuscuzeria.Domain.Entities
{
    public class Beverage : EntityBase
    {
        //PK
        public int BeverageId { get; private set; }

        public string BeverageName { get; private set; }
        public string Description { get; private set; }

        public int OrderId { get; private set; }
        public virtual Order Order { get; private set; }

        public Beverage(string beverageName, Order order)
        {
            BeverageName = beverageName;
            Order = order;

            new AddNotifications<Beverage>(this).IfNullOrInvalidLength(x => x.BeverageName, 2, 100,
                MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);

            AddNotifications(order);
        }

        protected Beverage()
        {

        }
    }
}
