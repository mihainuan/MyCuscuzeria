using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class CuscuzRepository : ICuscuzRepository
    {

        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        //Constructor using IoT (Injeção de Dependências)
        public CuscuzRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Cuscuz GetOneCuscuz(int cuscuzId)
        {
            return _cuscuzeriaContext.Cuscuz.FirstOrDefault(x => x.CuscuzId == cuscuzId);
        }

        public IEnumerable<Cuscuz> GetAllCuscuz()
        {
            //TODO: Review later
            return _cuscuzeriaContext.Cuscuz.ToList();
        }

        public Cuscuz AddCuscuz(Cuscuz cuscuz)
        {
            _cuscuzeriaContext.Cuscuz.Add(cuscuz);
            return cuscuz;
        }

        public void DeleteCuscuz(Cuscuz cuscuz)
        {
            _cuscuzeriaContext.Cuscuz.Remove(cuscuz);
        }

        public bool ExistOrder(int OrderId)
        {
            var exists = _cuscuzeriaContext.Cuscuz.FirstOrDefault(x => x.OrderId == OrderId);
            if (exists == null)
            {
                return false;
            }
            return true;
        }
    }
}