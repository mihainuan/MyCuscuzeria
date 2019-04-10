using MyCuscuzeria.Domain.Arguments.Promo;

namespace MyCuscuzeria.Domain.Services
{
    public interface IPromoService
    {
        /// <summary>
        /// Add Promo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddPromoResponse AddPromo(AddPromoRequest request);
    }
}