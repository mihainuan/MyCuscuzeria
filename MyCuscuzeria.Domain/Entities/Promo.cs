using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using System;

namespace MyCuscuzeria.Domain.Entities
{
    public class Promo : EntityBase
    {
        //PK
        public int PromoId { get; private set; }
        public string PromoTitle { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartsAt { get; private set; }
        public DateTime? EndsAt { get; private set; }
        public bool Active { get; private set; }

        public int OrderId { get; private set; }
        public virtual Order Order { get; private set; }


        public Promo(string promoTitle, string description, bool active, Order order)
        {
            PromoTitle = promoTitle;
            Description = description;
            Order = order;

            new AddNotifications<Promo>(this).IfNullOrInvalidLength(x => x.PromoTitle, 2, 100,
                    MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES)
                .IfNullOrInvalidLength(x => x.Description, 10, 200,
                    MSG.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES);

            AddNotifications(order);
        }
    }
}
