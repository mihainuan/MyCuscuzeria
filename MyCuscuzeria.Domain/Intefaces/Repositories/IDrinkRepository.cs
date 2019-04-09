using System.Collections.Generic;

namespace Cuscuzeria.Domain.Interfaces.Repositories
{
    public interface IDrinkRepository : IRepositoryBase<Drink>
    {
        /// <summary>
        /// Search by DrinkName
        /// </summary>
        /// <param name="drinkname"></param>
        /// <returns></returns>
        IEnumerable<Drink> FindByDrinkName(string drinkname);
    }
}