using MyCuscuzeria.Domain.Arguments.Beverage;

namespace MyCuscuzeria.Domain.Services
{
    public interface IBeverageService
    {
        /// <summary>
        /// Add Beverage
        /// </summary>
        /// <param name="beverage"></param>
        /// <returns></returns>
        AddBeverageResponse AddBeverage(AddBeverageRequest beverage);
    }
}