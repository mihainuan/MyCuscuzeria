using MyCuscuzeria.Domain.Arguments.Type;

namespace MyCuscuzeria.Domain.Services
{
    public interface ITypeService
    {
        /// <summary>
        /// Add/Save Type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddTypeResponse AddType(AddTypeRequest request);
    }
}