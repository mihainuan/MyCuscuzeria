using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Arguments.Cuscuzeiro;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface ICuscuzeiroService : IServiceBase
    {
        /// <summary>
        /// List ONE specific Cuscuzeiro
        /// </summary>
        /// <param name="Cuscuzeiroid"></param>
        /// <returns></returns>
        Cuscuzeiro GetOneCuscuzeiro(int cuscuzeiroId);

        /// <summary>
        /// List ALL Cuscuzeiroes
        /// </summary>
        /// <returns></returns>
        IEnumerable<CuscuzeiroResponse> GetAllCuscuzeiros();

        /// <summary>
        /// Add/Save Cuscuzeiro
        /// </summary>
        /// <param name="request"></param>
        /// <param name="CuscuzeiroId"></param>
        /// <returns></returns>
        CuscuzeiroResponse AddCuscuzeiro(AddCuscuzeiroRequest request, int orderId);

        /// <summary>
        /// Deletes ONE specific Cuscuzeiro
        /// </summary>
        /// <param name="CuscuzeiroId"></param>
        /// <returns></returns>
        Response RemoveCuscuzeiro(int cuscuzeiroId);

        /// <summary>
        /// Checks if there is an existing Order to a specific Cuscuzeiro
        /// </summary>
        /// <param name="CuscuzeiroId"></param>
        /// <returns></returns>
        bool ExistOrder(int cuscuzeiroId);
    }
}