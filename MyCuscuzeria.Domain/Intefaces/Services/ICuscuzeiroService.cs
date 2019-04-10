using MyCuscuzeria.Domain.Arguments.Cuscuzeiro;

namespace MyCuscuzeria.Domain.Services
{
    public interface ICuscuzeiroService
    {
        /// <summary>
        /// Add Cuscuzeiro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AddCuscuzeiroResponse AddCuscuzeiro(AddCuscuzeiroRequest request);
    }
}