using MyCuscuzeria.Domain.Arguments.Type;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;
using Response = MyCuscuzeria.Domain.Arguments.Base.Response;

namespace MyCuscuzeria.Domain.Services
{
    public interface ITypeService : IServiceBase
    {
        /// <summary>
        /// Add/Save Type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        TypeResponse AddType(AddTypeRequest request, int TypeId);

        /// <summary>
        /// List ALL types
        /// </summary>
        /// <returns></returns>
        IEnumerable<TypeResponse> ListTypes();

        /// <summary>
        /// Deletes ONE specific Type
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        Response RemoveType(int TypeId);
    }
}