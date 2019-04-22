using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IBeverageRepository
    {
        Beverage GetOneBeverage(int beverageId);

        IEnumerable<Beverage> GetAllBeverage();

        Beverage AddBeverage(Beverage beverage);

        void DeleteBeverage(Beverage beverage);

        bool ExistOrder(int OrderId);
    }
}