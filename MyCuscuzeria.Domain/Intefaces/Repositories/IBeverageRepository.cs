using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IBeverageRepository
    {
        Beverage GetBeverage(int beverageid);

        void SaveBeverage(Beverage beverage);
    }
}