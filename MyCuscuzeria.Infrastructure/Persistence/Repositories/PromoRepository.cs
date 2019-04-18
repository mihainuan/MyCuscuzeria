using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class PromoRepository : IPromoRepository
    {
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

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

        public Order ExistOrder(int promoId)
        {
            //_cuscuzeriaContext.
            return _cuscuzeriaContext.Orders.FirstOrDefault(x => x.PromoId == promoId);
        }
    }
}