using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Type> GetOneType(int typeid)
        {
            return _cuscuzeriaContext.Types.Where(x => x.TypeId == typeid).AsNoTracking().ToList();
        }

        public IEnumerable<Type> GetAllTypes()
        {
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

        Type ITypeRepository.GetOneType(int typeid)
        {
            throw new System.NotImplementedException();
        }
    }
}