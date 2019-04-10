using MyCuscuzeria.Domain.Arguments.Drink;

namespace MyCuscuzeria.Domain.Services
{
    public interface IDrinkService
    {
        /// <summary>
        /// Add Drink
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddDrinkResponse AddDrink(AddDrinkRequest request);
    }
}