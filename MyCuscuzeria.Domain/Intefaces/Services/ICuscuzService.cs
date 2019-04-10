using MyCuscuzeria.Domain.Arguments.Cuscuz;

namespace MyCuscuzeria.Domain.Services
{
    public interface ICuscuzService
    {
        /// <summary>
        /// Add Cuscuz
        /// </summary>
        /// <param name="cuscuz"></param>
        /// <returns></returns>
        AddCuscuzResponse AddCuscuz(AddCuscuzRequest cuscuz);
    }
}