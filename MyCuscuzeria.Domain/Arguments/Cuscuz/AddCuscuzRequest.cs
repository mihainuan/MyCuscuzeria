using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Arguments.Cuscuz
{
    public class AddCuscuzRequest
    {
        public int CuscuzId { get; set; }

        public string CuscuzName { get; set; }
        public string Description { get; set; }

        //public int OrderId { get; set; }
        //public int TypeId { get; set; }
        //public int AccompanimentId { get; set; }

        //FK (one-to-one)
        public virtual Entities.Order Order { get; set; }
        public virtual Entities.Type Type { get; set; }

        //FK (one-to-many)
        public virtual ICollection<Entities.Accompaniment> Accompaniments { get; set; }

        void Cuscuz()
        {
            Accompaniments = new List<Entities.Accompaniment>();
        }
    }
}