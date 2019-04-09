using Cuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace Cuscuzeria.Domain.Interfaces.Repositories
{
    public interface ICuscuzRepository : IRepositoryBase<Cuscuz>
    {
        /// <summary>
        /// Search by CuscuzeiroName
        /// </summary>
        /// <param name="cuscuzname"></param>
        /// <returns></returns>
        IEnumerable<Cuscuz> FindByCuscuzName(string cuscuzname);
    }
}