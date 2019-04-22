using MyCuscuzeria.Domain.Entities;
using System.Collections.Generic;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IAccompanimentRepository
    {
        Accompaniment GetOneAccompaniment(int AccompanimentId);

        IEnumerable<Accompaniment> GetAllAccompaniment();

        Accompaniment AddAccompaniment(Accompaniment Accompaniment);

        void DeleteAccompaniment(Accompaniment Accompaniment);

        bool ExistCuscuz(int typeId);
    }
}