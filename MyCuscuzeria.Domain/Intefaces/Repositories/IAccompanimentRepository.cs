using Cuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace Cuscuzeria.Domain.Interfaces.Repositories
{
    public interface IAccompanimentRepository : IRepositoryBase<Accompaniment>
    {
        /// <summary>
        /// Search by AccompanimentName
        /// </summary>
        /// <param name="accompanimentname"></param>
        /// <returns></returns>
        IEnumerable<Accompaniment> FindByAccompanimentName(string accompanimentname);
    }
}