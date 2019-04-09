using MyCuscuzeria.Domain.Entities.Base;
using System;

namespace Cuscuzeria.Domain.Entities
{
    public class Cuscuzeiro : EntityBase
    {
        //PK
        public int CuscuzeiroId { get; set; }

        public string CuscuzeiroName { get; set; }
        public int Age { get; set; }
        public DateTime? StartDate { get; set; }
        public string UrlImg { get; set; }

        //public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
