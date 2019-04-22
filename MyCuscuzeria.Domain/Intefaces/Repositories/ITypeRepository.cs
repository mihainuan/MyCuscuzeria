using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface ITypeRepository
    {
        Type GetOneType(int typeid);

        IEnumerable<Type> GetAllTypes();

        Type AddType(Type type);

        void DeleteType(Type type);

        bool ExistCuscuz(int typeId);
    }
}