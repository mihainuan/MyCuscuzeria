namespace MyCuscuzeria.Domain.Arguments.Order
{
    public class AddOrderResponse
    {
        public int OrderId { get; set; }

        public AddOrderResponse(int orderid)
        {
            orderid = OrderId;
        }
    }
}