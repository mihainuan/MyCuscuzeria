using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IPromoRepository
    {
        Promo GetOnePromo(int promoid);

        IEnumerable<Promo> GetAllPromo();

        Promo AddPromo(Promo promo);

        void DeletePromo(Promo promo);

        bool ExistOrder(int promoId);
    }
}