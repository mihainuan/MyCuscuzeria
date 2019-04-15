namespace MyCuscuzeria.Infrastructure.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}