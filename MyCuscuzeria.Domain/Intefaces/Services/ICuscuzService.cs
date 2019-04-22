using MyCuscuzeria.Domain.Arguments.Cuscuz;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface ICuscuzService : IServiceBase
    {
        /// <summary>
        /// Add Cuscuz
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CuscuzResponse AddCuscuz(AddCuscuzRequest request);






        /// <summary>
        /// Checks if there is an existing Type in specific Cuscuz
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        bool ExistingType(int typeId);
    }
}