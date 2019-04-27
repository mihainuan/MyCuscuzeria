using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface ICuscuzRepository
    {
        Cuscuz GetOneCuscuz(int cuscuzId);

        Cuscuz FindCuscuz(string cuscuzName);

        IEnumerable<Cuscuz> GetAllCuscuz();

        Cuscuz AddCuscuz(Cuscuz cuscuz);

        void DeleteCuscuz(Cuscuz cuscuz);

        bool ExistOrder(int OrderId);
    }
}