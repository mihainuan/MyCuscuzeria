using MyCuscuzeria.Domain.Entities.Base;
using MyCuscuzeria.Domain.Resources;
using prmToolkit.NotificationPattern;
using System;

namespace MyCuscuzeria.Domain.Entities
{
    public class Promo : EntityBase
    {
        //PK
        public int PromoId { get; set; }
        public string PromoTitle { get; set; }
        public string Description { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public bool Active { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }


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
