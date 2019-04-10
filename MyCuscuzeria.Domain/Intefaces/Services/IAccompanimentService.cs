using MyCuscuzeria.Domain.Arguments.Accompaniment;

namespace MyCuscuzeria.Domain.Services
{
    public interface IAccompanimentService
    {
        /// <summary>
        /// Add Accompaniment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddAccompanimentResponse AddAccompaniment(AddAccompanimentRequest request);
    }
}