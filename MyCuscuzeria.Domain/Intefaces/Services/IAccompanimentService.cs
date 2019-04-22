using MyCuscuzeria.Domain.Arguments.Accompaniment;
using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface IAccompanimentService : IServiceBase
    {
        /// <summary>
        /// List ONE specific Accompaniments
        /// </summary>
        /// <param name="Accompanimentid"></param>
        /// <returns></returns>
        Accompaniment GetOneAccompaniment(int Accompanimentid);

        /// <summary>
        /// List ALL Accompaniments
        /// </summary>
        /// <returns></returns>
        IEnumerable<AccompanimentResponse> GetAllAccompaniments();

        /// <summary>
        /// Add/Save Accompaniment
        /// </summary>
        /// <param name="request"></param>
        /// <param name="AccompanimentId"></param>
        /// <returns></returns>
        AccompanimentResponse AddAccompaniment(AddAccompanimentRequest request, int AccompanimentId);

        /// <summary>
        /// Deletes ONE specific Accompaniment
        /// </summary>
        /// <param name="AccompanimentId"></param>
        /// <returns></returns>
        Response RemoveAccompaniment(int AccompanimentId);

        /// <summary>
        /// Checks if there is a CUSCUZ attch w/ typeId
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        bool ExistCuscuz(int typeId);
    }
}