using OnlineBookSubscription.Catalog.Data.Repository.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();

        IGenericRepository<Book> Books { get; }
        IGenericRepository<Subscription> Subscription { get; }
    }
}