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
        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        //Constructor using IoC (Injeção de Dependências)
        public TypeRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Type GetOneType(int typeId)
        {
            return _cuscuzeriaContext.Types.FirstOrDefault(x => x.TypeId == typeId);
        }
        //Can be an IQueryable (Section 2, Class 21 (33:20))
        public IEnumerable<Type> GetAllTypes()
        {
            //TODO: Review later (AsNoTracking => faster queries)
            return _cuscuzeriaContext.Types.AsNoTracking().ToList();
        }

        public Type AddType(Type type)
        {
            _cuscuzeriaContext.Types.Add(type);
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