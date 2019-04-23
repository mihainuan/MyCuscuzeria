using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class CuscuzeiroRepository : ICuscuzeiroRepository
    {
        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        //Constructor using IoC (Injeção de Dependências)
        public CuscuzeiroRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Cuscuzeiro GetOneCuscuzeiro(int cuscuzeiroId)
        {
            return _cuscuzeriaContext.Cuscuzeiros.FirstOrDefault(x => x.CuscuzeiroId == cuscuzeiroId);
        }

        public IEnumerable<Cuscuzeiro> GetAllCuscuzeiro()
        {
            //TODO: Review later
            return _cuscuzeriaContext.Cuscuzeiros.ToList();
        }

        public Cuscuzeiro AddCuscuzeiro(Cuscuzeiro cuscuzeiro)
        {
            _cuscuzeriaContext.Cuscuzeiros.Add(cuscuzeiro);
            return cuscuzeiro;
        }

        public void DeleteCuscuzeiro(Cuscuzeiro cuscuzeiro)
        {
            _cuscuzeriaContext.Cuscuzeiros.Remove(cuscuzeiro);
        }

        public bool ExistOrder(int OrderId)
        {
            var exists = _cuscuzeriaContext.Cuscuzeiros.FirstOrDefault(x => x.OrderId == OrderId);
            if (exists == null)
            {
                return false;
            }
            return true;
        }
    }
}