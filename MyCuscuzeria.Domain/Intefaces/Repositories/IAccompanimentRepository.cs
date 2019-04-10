using MyCuscuzeria.Domain.Entities;

namespace MyCuscuzeria.Domain.Intefaces.Repositories
{
    public interface IAccompanimentRepository
    {
        Accompaniment GetAccompaniment(int accompanimentid);

        void SaveAccompaniment(Accompaniment accompaniment);
    }
}