using Cuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace Cuscuzeria.Domain.Interfaces.Repositories
{
    public interface ITypeRepository : IRepositoryBase<Type>
    {
        /// <summary>
        /// Search by TypeName
        /// </summary>
        /// <param name="typename"></param>
        /// <returns></returns>
        IEnumerable<Type> FindByTypeName(string typename);
    }
}