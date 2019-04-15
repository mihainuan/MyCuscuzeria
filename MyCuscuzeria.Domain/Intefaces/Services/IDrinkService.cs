using MyCuscuzeria.Domain.Arguments.Drink;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface IDrinkService : IServiceBase
    {
        /// <summary>
        /// Add Drink
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddDrinkResponse AddDrink(AddDrinkRequest request);
    }
}