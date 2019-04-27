using MyCuscuzeria.Domain.Arguments.Base;
using MyCuscuzeria.Domain.Arguments.Cuscuz;
using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Services.Base;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Services
{
    public interface ICuscuzService : IServiceBase
    {
        /// <summary>
        /// List ONE specific Cuscuz
        /// </summary>
        /// <param name="Cuscuzid"></param>
        /// <returns></returns>
        Cuscuz GetOneCuscuz(int cuscuzId);

        /// <summary>
        /// Find ONE specific Cuscuz by Name
        /// </summary>
        /// <param name="Cuscuzid"></param>
        /// <returns></returns>
        Cuscuz FindCuscuz(string cuscuzName);

        /// <summary>
        /// List ALL Cuscuzes
        /// </summary>
        /// <returns></returns>
        IEnumerable<CuscuzResponse> GetAllCuscuzes();

        /// <summary>
        /// Add/Save Cuscuz
        /// </summary>
        /// <param name="request"></param>
        /// <param name="CuscuzId"></param>
        /// <returns></returns>
        CuscuzResponse AddCuscuz(AddCuscuzRequest request, int orderId);

        /// <summary>
        /// Deletes ONE specific Cuscuz
        /// </summary>
        /// <param name="CuscuzId"></param>
        /// <returns></returns>
        Response RemoveCuscuz(int cuscuzId);

        /// <summary>
        /// Checks if there is an existing Order to a specific Cuscuz
        /// </summary>
        /// <param name="cuscuzId"></param>
        /// <returns></returns>
        bool ExistOrder(int cuscuzId);
    }
}