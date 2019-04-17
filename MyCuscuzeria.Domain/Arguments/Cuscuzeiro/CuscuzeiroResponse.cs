using System;

namespace MyCuscuzeria.Domain.Arguments.Cuscuzeiro
{
    public class CuscuzeiroResponse
    {
        //PK
        public int CuscuzeiroId { get; set; }

        public string CuscuzeiroName { get; set; }
        public int Age { get; set; }
        public DateTime? StartDate { get; set; }
        public string UrlImg { get; set; }

        public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }


        public static explicit operator CuscuzeiroResponse(Entities.Cuscuzeiro entity)
        {
            return new CuscuzeiroResponse()
            {
                CuscuzeiroId = entity.CuscuzeiroId,
                CuscuzeiroName = entity.CuscuzeiroName,
                Age = entity.Age,
                StartDate = entity.StartDate,
                UrlImg = entity.UrlImg,
                OrderId = entity.OrderId,
                Order = entity.Order

            };
        }
    }
}