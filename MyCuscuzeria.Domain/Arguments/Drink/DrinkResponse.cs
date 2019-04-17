namespace MyCuscuzeria.Domain.Arguments.Drink
{
    public class DrinkResponse
    {
        //PK
        public int DrinkId { get; set; }

        public string DrinkName { get; set; }
        public string Description { get; set; }

        public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }

        public static explicit operator DrinkResponse(Entities.Drink entity)
        {
            return new DrinkResponse()
            {
                DrinkId = entity.DrinkId,
                DrinkName = entity.DrinkName,
                Description = entity.Description,
                Order = entity.Order
            };
        }
    }
}