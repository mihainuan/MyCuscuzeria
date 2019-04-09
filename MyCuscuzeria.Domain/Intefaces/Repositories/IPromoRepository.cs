using Cuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace Cuscuzeria.Domain.Interfaces.Repositories
{
    public interface IPromoRepository : IRepositoryBase<Promo>
    {
        /// <summary>
        /// Search by PromoName
        /// </summary>
        /// <param name="promoname"></param>
        /// <returns></returns>
        IEnumerable<Promo> FindByPromoName(string promoname);
    }
}