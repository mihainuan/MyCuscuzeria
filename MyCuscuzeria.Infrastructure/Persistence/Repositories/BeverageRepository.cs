using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class BeverageRepository : IBeverageRepository
    {
        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        //Constructor using IoT (Injeção de Dependências)
        public BeverageRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Beverage GetOneBeverage(int beverageId)
        {
            return _cuscuzeriaContext.Beverages.FirstOrDefault(x => x.BeverageId == beverageId);
        }

        public IEnumerable<Beverage> GetAllBeverage()
        {
            //TODO: Review later
            return _cuscuzeriaContext.Beverages.ToList();
        }

        public Beverage AddBeverage(Beverage beverage)
        {
            _cuscuzeriaContext.Beverages.Add(beverage);
            return beverage;
        }

        public void DeleteBeverage(Beverage beverage)
        {
            _cuscuzeriaContext.Beverages.Remove(beverage);
        }

        public bool ExistOrder(int OrderId)
        {
            var exists = _cuscuzeriaContext.Beverages.FirstOrDefault(x => x.OrderId == OrderId);
            if (exists == null)
            {
                return false;
            }
            return true;
        }
    }
}