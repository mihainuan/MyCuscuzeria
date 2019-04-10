namespace MyCuscuzeria.Domain.Arguments.Accompaniment
{
    public class AddAccompanimentRequest
    {
        public int AccompanimentId { get; set; }

        public string AccompanimentName { get; set; }
        public string Description { get; set; }

        //public int CuscuzId { get; set; }
        public virtual Entities.Cuscuz Cuscuz { get; set; }
    }
}