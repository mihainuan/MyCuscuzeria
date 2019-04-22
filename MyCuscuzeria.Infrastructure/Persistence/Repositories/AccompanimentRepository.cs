using MyCuscuzeria.Domain.Entities;
using MyCuscuzeria.Domain.Intefaces.Repositories;
using MyCuscuzeria.Infrastructure.Persistence.EF;
using System.Collections.Generic;
using System.Linq;

namespace MyCuscuzeria.Infrastructure.Persistence.Repositories
{
    public class AccompanimentRepository : IAccompanimentRepository
    {
        //Database context
        private readonly MyCuscuzeriaContext _cuscuzeriaContext;

        public AccompanimentRepository(MyCuscuzeriaContext cuscuzeriaContext)
        {
            _cuscuzeriaContext = cuscuzeriaContext;
        }

        public Accompaniment GetOneAccompaniment(int accompanimentId)
        {
            return _cuscuzeriaContext.Accompaniments.FirstOrDefault(x => x.AccompanimentId == accompanimentId);
        }

        public IEnumerable<Accompaniment> GetAllAccompaniment()
        {
            //TODO: Review later
            return _cuscuzeriaContext.Accompaniments.ToList();
        }

        public Accompaniment AddAccompaniment(Accompaniment accompaniment)
        {
            _cuscuzeriaContext.Accompaniments.Add(accompaniment);
            return accompaniment;
        }

        public void DeleteAccompaniment(Accompaniment accompaniment)
        {
            _cuscuzeriaContext.Accompaniments.Remove(accompaniment);
        }

        public bool ExistCuscuz(int accompanimentId)
        {
            var exists = _cuscuzeriaContext.Accompaniments.FirstOrDefault(x => x.AccompanimentId == accompanimentId);
            if (exists == null)
            {
                return false;
            }
            return true;
        }
    }
}