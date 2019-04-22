using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class PromoRepository : IPromoRepository
    {
        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        //Constructor using IoT (Injeção de Dependências)
        public PromoRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Promo GetOnePromo(int promoid)
        {
            return _cuscuzeriaContext.Promos.FirstOrDefault(x => x.PromoId == promoid);
        }

        public IEnumerable<Promo> GetAllPromo()
        {
            //TODO: Review later
            return _cuscuzeriaContext.Promos.ToList();
        }

        public Promo AddPromo(Promo promo)
        {
            _cuscuzeriaContext.Promos.Add(promo);
            return promo;
        }

        public void DeletePromo(Promo promo)
        {
            _cuscuzeriaContext.Remove(promo);
        }

        public bool ExistOrder(int promoId)
        {
            var exists = _cuscuzeriaContext.Promos.FirstOrDefault(x => x.PromoId == promoId);

            if (exists == null)
            {
                return false;
            }

            return true;

        }
    }
}