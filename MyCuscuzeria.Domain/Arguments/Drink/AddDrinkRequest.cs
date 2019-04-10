namespace MyCuscuzeria.Domain.Arguments.Drink
{
    public class AddDrinkRequest
    {
        public int DrinkId { get; set; }

        public string DrinkName { get; set; }
        public string Description { get; set; }

        //public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }
    }
}