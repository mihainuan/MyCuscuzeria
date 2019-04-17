namespace MyCuscuzeria.Domain.Arguments.Beverage
{
    public class BeverageResponse
    {
        //PK
        public int BeverageId { get; set; }
        public string BeverageName { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public virtual Entities.Order Order { get; set; }

        public static explicit operator BeverageResponse(Entities.Beverage entity)
        {
            return new BeverageResponse()
            {
                BeverageId = entity.BeverageId,
                BeverageName = entity.BeverageName,
                Description = entity.Description,
                OrderId = entity.OrderId,
                Order = entity.Order
            };
        }
    }
}