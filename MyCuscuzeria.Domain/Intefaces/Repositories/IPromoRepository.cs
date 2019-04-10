using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IPromoRepository
    {
        Promo GetPromo(int promoid);

        void SavePromo(Promo promo);
    }
}