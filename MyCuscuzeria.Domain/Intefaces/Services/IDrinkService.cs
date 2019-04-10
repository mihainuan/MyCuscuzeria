using MyCuscuzeria.Domain.Arguments.Drink;

namespace MyCuscuzeria.Domain.Services
{
    public interface IDrinkService
    {
        /// <summary>
        /// Add Drink
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        AddDrinkResponse AddDrink(AddDrinkRequest drink);
    }
}