using System;

namespace MyCuscuzeria.Domain.Arguments.Cuscuzeiro
{
    public class AddCuscuzeiroRequest
    {
        public int CuscuzeiroId { get; set; }

        public string CuscuzeiroName { get; set; }
        public int Age { get; set; }
        public DateTime? StartDate { get; set; }
        public string UrlImg { get; set; }

        //public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }
    }
}