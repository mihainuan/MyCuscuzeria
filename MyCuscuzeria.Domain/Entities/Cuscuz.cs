using MyCuscuzeria.Domain.Entities.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Entities
{
    public class Cuscuz : EntityBase
    {
        //PK
        public int CuscuzId { get; private set; }

        public string CuscuzName { get; private set; }
        public string Description { get; private set; }

        public int OrderId { get; private set; }
        public int TypeId { get; private set; }
        public int AccompanimentId { get; private set; }

        //FK (one-to-one)
        public virtual Order Order { get; private set; }
        public virtual Type Type { get; private set; }

        //FK (one-to-many)
        public virtual ICollection<Accompaniment> Accompaniments { get; private set; }

        public Cuscuz()
        {
            Accompaniments = new List<Accompaniment>();
        }
    }
}
