using MyCuscuzeria.Domain.Arguments.Beverage;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface IBeverageService : IServiceBase
    {
        /// <summary>
        /// Add Beverage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BeverageResponse AddBeverage(AddBeverageRequest request);
    }
}