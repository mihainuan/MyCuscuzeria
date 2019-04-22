using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;
using Type = MyCuscuzeria.Domain.Entities.Type;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        //Constructor using IoT (Injeção de Dependências)
        public TypeRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Type GetOneType(int typeid)
        {
            return _cuscuzeriaContext.Types.FirstOrDefault(x => x.TypeId == typeid);
        }

        public IEnumerable<Type> GetAllTypes()
        {
            //TODO: Review later
            return _cuscuzeriaContext.Types.ToList();
        }

        public Type AddType(Type type)
        {
            _cuscuzeriaContext.Add(type);
            return type;
        }

        public void DeleteType(Type type)
        {
            _cuscuzeriaContext.Types.Remove(type);
        }

        public bool ExistCuscuz(int typeId)
        {
            var exists = _cuscuzeriaContext.Types.FirstOrDefault(x => x.TypeId == typeId);

            if (exists == null)
            {
                return false;
            }
            return true;
        }
    }
}