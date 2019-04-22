using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface ICuscuzeiroRepository
    {
        Cuscuzeiro GetOneCuscuzeiro(int CuscuzeiroId);

        IEnumerable<Cuscuzeiro> GetAllCuscuzeiro();

        Cuscuzeiro AddCuscuzeiro(Cuscuzeiro Cuscuzeiro);

        void DeleteCuscuzeiro(Cuscuzeiro Cuscuzeiro);

        bool ExistOrder(int OrderId);
    }
}