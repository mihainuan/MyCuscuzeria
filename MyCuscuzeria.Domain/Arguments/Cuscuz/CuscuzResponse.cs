using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Arguments.Cuscuz
{
    public class CuscuzResponse
    {
        //PK
        public int CuscuzId { get; set; }

        public string CuscuzName { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }
        public int TypeId { get; set; }
        public int AccompanimentId { get; set; }

        //FK (one-to-one)
        public virtual Entities.Order Order { get; set; }
        public virtual Entities.Type Type { get; set; }

        //FK (one-to-many)
        public virtual ICollection<Entities.Accompaniment> Accompaniments { get; set; }


        public static explicit operator CuscuzResponse(Entities.Cuscuz entity)
        {
            return new CuscuzResponse()
            {
                CuscuzId = entity.CuscuzId,
                CuscuzName = entity.CuscuzName,
                Description = entity.Description,
                OrderId = entity.OrderId,
                TypeId = entity.TypeId,
                AccompanimentId = entity.AccompanimentId,
                Order = entity.Order,
                Type = entity.Type,
                Accompaniments = entity.Accompaniments
            };
        }
    }
}