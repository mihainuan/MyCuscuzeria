namespace MyCuscuzeria.Domain.Arguments.Beverage
{
    public class AddBeverageResponse
    {
        public int BeverageId { get; set; }

        public AddBeverageResponse(int beverageid)
        {
            beverageid = BeverageId;
        }
    }
}