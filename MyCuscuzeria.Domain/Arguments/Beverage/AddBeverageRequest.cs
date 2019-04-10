namespace MyCuscuzeria.Domain.Arguments.Beverage
{
    public class AddBeverageRequest
    {
        public int BeverageId { get; set; }

        public string BeverageName { get; set; }
        public string Description { get; set; }

        //public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }
    }
}