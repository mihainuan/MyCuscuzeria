namespace Cuscuzeria.Domain.Entities
{
    public class Cuscuz
    {
        public int CuscuzId { get; set; }
        public string CuscuzName { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }
        public int TypeId { get; set; }
        public int AccompanimentId { get; set; }

        ////FK (one-to-one)
        //public virtual Order Order { get; set; }
        //public virtual Type Type { get; set; }

        ////FK (one-to-many)
        //public virtual ICollection<Accompaniment> Accompaniments { get; set; }

        //public Cuscuz()
        //{
        //    Accompaniments = new List<Accompaniment>();
        //}
    }
}
