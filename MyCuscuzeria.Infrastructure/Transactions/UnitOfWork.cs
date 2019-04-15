using MyCuscuzeria.Infrastructure.Persistence.EF;

namespace MyCuscuzeria.Infrastructure.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyCuscuzeriaContext _context;

        public UnitOfWork(MyCuscuzeriaContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
