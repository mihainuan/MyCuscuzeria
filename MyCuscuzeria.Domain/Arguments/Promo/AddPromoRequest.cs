using System;

namespace MyCuscuzeria.Domain.Arguments.Promo
{
    public class AddPromoRequest
    {
        public int PromoId { get; set; }

        public string PromoTitle { get; set; }
        public string Description { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public bool Active { get; set; }

        //public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }
    }
}