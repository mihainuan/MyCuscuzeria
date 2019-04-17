using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;
using Type = MyCuscuzeria.Domain.Entities.Type;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

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
            _cuscuzeriaContext.Remove(type);
        }
    }
}