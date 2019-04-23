using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        //Constructor using IoC (Injeção de Dependências)
        public DrinkRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Drink GetOneDrink(int drinkId)
        {
            return _cuscuzeriaContext.Drinks.FirstOrDefault(x => x.DrinkId == drinkId);
        }

        public IEnumerable<Drink> GetAllDrink()
        {
            //TODO: Review later
            return _cuscuzeriaContext.Drinks.ToList();
        }

        public Drink AddDrink(Drink drink)
        {
            _cuscuzeriaContext.Drinks.Add(drink);
            return drink;
        }

        public void DeleteDrink(Drink drink)
        {
            _cuscuzeriaContext.Drinks.Remove(drink);
        }

        public bool ExistOrder(int OrderId)
        {
            var exists = _cuscuzeriaContext.Drinks.FirstOrDefault(x => x.OrderId == OrderId);
            if (exists == null)
            {
                return false;
            }
            return true;
        }
    }
}