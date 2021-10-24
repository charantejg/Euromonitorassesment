using OnlineBookSubscription.Catalog.Domain.Entities;
using OnlineBookSubscription.Identity.Data.Repository.Interfaces;

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