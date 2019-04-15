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
        AddCuscuzResponse AddCuscuz(AddCuscuzRequest request);
    }
}