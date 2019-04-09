using Cuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace Cuscuzeria.Domain.Interfaces.Repositories
{
    public interface ICuscuzeiroRepository : IRepositoryBase<Cuscuzeiro>
    {
        /// <summary>
        /// Search by CuscuzeiroName
        /// </summary>
        /// <param name="cuscuzeironame"></param>
        /// <returns></returns>
        IEnumerable<Cuscuzeiro> FindByCuscuzeiroName(string cuscuzeironame);
    }
}