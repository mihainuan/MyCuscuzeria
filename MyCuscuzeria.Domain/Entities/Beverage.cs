using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;

namespace MyCuscuzeria.Domain.Entities
{
    public class Beverage : EntityBase
    {
        //PK
        public int BeverageId { get; set; }

        public string BeverageName { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Beverage(string beverageName, Order order)
        {
            BeverageName = beverageName;
            Order = order;

            new AddNotifications<Beverage>(this).IfNullOrInvalidLength(x => x.BeverageName, 2, 100,
                MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);

            AddNotifications(order);
        }
    }
}
