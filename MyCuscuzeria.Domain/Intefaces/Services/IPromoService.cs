using MyCuscuzeria.Domain.Arguments.Promo;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface IPromoService : IServiceBase
    {
        /// <summary>
        /// Add Promo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddPromoResponse AddPromo(AddPromoRequest request);
    }
}