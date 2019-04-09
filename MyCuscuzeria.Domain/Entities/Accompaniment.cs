using MyCuscuzeria.Domain.Entities.Base;

namespace Cuscuzeria.Domain.Entities
{
    public class Accompaniment : EntityBase
    {
        //PK
        public int AccompanimentId { get; set; }

        public string AccompanimentName { get; set; }
        public string Description { get; set; }

        //public int CuscuzId { get; set; }
        public virtual Cuscuz Cuscuz { get; set; }
    }
}
