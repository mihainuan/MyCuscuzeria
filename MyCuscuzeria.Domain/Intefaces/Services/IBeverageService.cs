using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Arguments.Beverage;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface IBeverageService : IServiceBase
    {
        /// <summary>
        /// List ONE specific Beverage
        /// </summary>
        /// <param name="Beverageid"></param>
        /// <returns></returns>
        Beverage GetOneBeverage(int BeverageId);

        /// <summary>
        /// List ALL Beveragees
        /// </summary>
        /// <returns></returns>
        IEnumerable<BeverageResponse> GetAllBeverages();

        /// <summary>
        /// Add/Save Beverage
        /// </summary>
        /// <param name="request"></param>
        /// <param name="BeverageId"></param>
        /// <returns></returns>
        BeverageResponse AddBeverage(AddBeverageRequest request, int orderId);

        /// <summary>
        /// Deletes ONE specific Beverage
        /// </summary>
        /// <param name="BeverageId"></param>
        /// <returns></returns>
        Response RemoveBeverage(int BeverageId);

        /// <summary>
        /// Checks if there is an existing Order to a specific Beverage
        /// </summary>
        /// <param name="BeverageId"></param>
        /// <returns></returns>
        bool ExistOrder(int BeverageId);
    }
}