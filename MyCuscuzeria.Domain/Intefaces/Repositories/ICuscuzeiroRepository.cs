using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface ICuscuzeiroRepository
    {
        Cuscuzeiro GetCuscuzeiro(int cuscuzeiroid);

        void SaveCuscuzeiro(Cuscuzeiro cuscuzeiro);
    }
}