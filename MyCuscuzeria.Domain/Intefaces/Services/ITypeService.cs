using MyCuscuzeria.Domain.Arguments.Type;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface ITypeService : IServiceBase
    {
        /// <summary>
        /// Add/Save Type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddTypeResponse AddType(AddTypeRequest request);
    }
}