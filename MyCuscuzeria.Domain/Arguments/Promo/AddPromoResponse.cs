namespace MyCuscuzeria.Domain.Arguments.Promo
{
    public class AddPromoResponse
    {
        public int PromoId { get; set; }

        public AddPromoResponse(int promoid)
        {
            promoid = PromoId;
        }
    }
}