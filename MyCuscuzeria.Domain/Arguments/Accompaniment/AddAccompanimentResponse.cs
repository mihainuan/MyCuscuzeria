namespace MyCuscuzeria.Domain.Arguments.Accompaniment
{
    public class AddAccompanimentResponse
    {
        public int AccompanimentId { get; set; }

        public AddAccompanimentResponse(int accompanimentid)
        {
            accompanimentid = AccompanimentId;
        }
    }
}