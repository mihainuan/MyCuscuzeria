using MyCuscuzeria.Domain.Arguments.Accompaniment;
using MyCuscuzeria.Domain.Services.Base;

namespace MyCuscuzeria.Domain.Services
{
    public interface IAccompanimentService : IServiceBase
    {
        /// <summary>
        /// Add Accompaniment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddAccompanimentResponse AddAccompaniment(AddAccompanimentRequest request);
    }
}