using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface ITypeRepository
    {
        Type GetType(int typeid);

        void SaveType(Type type);
    }
}