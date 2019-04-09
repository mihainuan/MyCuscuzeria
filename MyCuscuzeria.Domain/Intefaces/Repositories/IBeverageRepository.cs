using Cuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace Cuscuzeria.Domain.Interfaces.Repositories
{
    public interface IBeverageRepository : IRepositoryBase<Beverage>
    {
        /// <summary>
        /// Search by BeverageName
        /// </summary>
        /// <param name="beveragename"></param>
        /// <returns></returns>
        IEnumerable<Beverage> FindByBeverageName(string beveragename);
    }
}