using MyCuscuzeria.Domain.Arguments.Cuscuzeiro;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface ICuscuzeiroService : IServiceBase
    {
        /// <summary>
        /// Add Cuscuzeiro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CuscuzeiroResponse AddCuscuzeiro(AddCuscuzeiroRequest request);
    }
}