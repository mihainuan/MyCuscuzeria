using System;

namespace MyCuscuzeria.Domain.Arguments.Promo
{
    public class PromoResponse
    {
        public int PromoId { get; set; }

        public string PromoTitle { get; set; }
        public string Description { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }
        public bool Active { get; set; }

        public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }

        public static explicit operator PromoResponse(Entities.Promo entity)
        {
            return new PromoResponse()
            {
                PromoId = entity.PromoId,
                PromoTitle = entity.PromoTitle,
                Description = entity.Description,
                StartsAt = entity.StartsAt,
                EndsAt = entity.EndsAt,
                Active = entity.Active,
                OrderId = entity.OrderId,
                Order = entity.Order
            };
        }
    }
}