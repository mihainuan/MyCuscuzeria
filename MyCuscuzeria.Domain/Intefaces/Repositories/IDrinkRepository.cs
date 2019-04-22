using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IDrinkRepository
    {
        Drink GetOneDrink(int drinkId);

        IEnumerable<Drink> GetAllDrink();

        Drink AddDrink(Drink drink);

        void DeleteDrink(Drink drink);

        bool ExistOrder(int OrderId);
    }
}