using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface ICuscuzRepository
    {
        Cuscuz GetCuscuz(int cuscuzid);

        void SaveCuscuz(Cuscuz cuscuz);
    }
}