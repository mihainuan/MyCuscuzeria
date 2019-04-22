using MyCuscuzeria.Domain.Arguments.Type;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;
using Response = MyCuscuzeria.Domain.Arguments.Base.Response;

namespace MyCuscuzeria.Domain.Services
{
    public interface ITypeService : IServiceBase
    {
        /// <summary>
        /// List ONE specific Types
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        Type GetOneType(int typeid);

        /// <summary>
        /// List ALL types
        /// </summary>
        /// <returns></returns>
        IEnumerable<TypeResponse> GetAllTypes();

        /// <summary>
        /// Add/Save Type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        TypeResponse AddType(AddTypeRequest request, int TypeId);

        /// <summary>
        /// Deletes ONE specific Type
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        Response RemoveType(int TypeId);

        /// <summary>
        /// Checks if there is a CUSCUZ attch w/ typeId
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        bool ExistCuscuz(int typeId);
    }
}