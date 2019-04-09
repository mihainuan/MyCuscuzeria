using MyCuscuzeria.Domain.Entities.Base;
using System;

namespace Cuscuzeria.Domain.Entities
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

        //public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
