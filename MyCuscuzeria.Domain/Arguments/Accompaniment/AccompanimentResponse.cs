namespace MyCuscuzeria.Domain.Arguments.Accompaniment
{
    public class AccompanimentResponse
    {
        //PK
        public int AccompanimentId { get; set; }

        public string AccompanimentName { get; set; }
        public string Description { get; set; }

        public int CuscuzId { get; set; }
        public virtual Entities.Cuscuz Cuscuz { get; set; }

        public static explicit operator AccompanimentResponse(Entities.Accompaniment entity)
        {
            return new AccompanimentResponse()
            {
                AccompanimentId = entity.AccompanimentId,
                AccompanimentName = entity.AccompanimentName,
                Description = entity.Description,
                CuscuzId = entity.CuscuzId,
                Cuscuz = entity.Cuscuz
            };
        }
    }
}