using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Arguments.Promo;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface IPromoService : IServiceBase
    {
        /// <summary>
        /// List ONE specific Promos
        /// </summary>
        /// <param name="Promoid"></param>
        /// <returns></returns>
        Promo GetOnePromo(int promoId);

        /// <summary>
        /// List ALL Promos
        /// </summary>
        /// <returns></returns>
        IEnumerable<PromoResponse> GetAllPromos();

        /// <summary>
        /// Add/Save Promo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="PromoId"></param>
        /// <returns></returns>
        PromoResponse AddPromo(AddPromoRequest request, int promoId);

        /// <summary>
        /// Deletes ONE specific Promo
        /// </summary>
        /// <param name="PromoId"></param>
        /// <returns></returns>
        Response RemovePromo(int promoId);
    }
}