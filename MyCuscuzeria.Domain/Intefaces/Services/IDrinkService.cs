using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Arguments.Drink;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface IDrinkService : IServiceBase
    {
        /// <summary>
        /// List ONE specific Drinks
        /// </summary>
        /// <param name="Drinkid"></param>
        /// <returns></returns>
        Drink GetOneDrink(int DrinkId);

        /// <summary>
        /// List ALL Drinks
        /// </summary>
        /// <returns></returns>
        IEnumerable<DrinkResponse> GetAllDrinks();

        /// <summary>
        /// Add/Save Drink
        /// </summary>
        /// <param name="request"></param>
        /// <param name="DrinkId"></param>
        /// <returns></returns>
        DrinkResponse AddDrink(AddDrinkRequest request, int orderId);

        /// <summary>
        /// Deletes ONE specific Drink
        /// </summary>
        /// <param name="DrinkId"></param>
        /// <returns></returns>
        Response RemoveDrink(int DrinkId);

        /// <summary>
        /// Checks if there is a ORDER attch w/ DrinkId
        /// </summary>
        /// <param name="DrinkId"></param>
        /// <returns></returns>
        bool ExistOrder(int DrinkId);
    }
}