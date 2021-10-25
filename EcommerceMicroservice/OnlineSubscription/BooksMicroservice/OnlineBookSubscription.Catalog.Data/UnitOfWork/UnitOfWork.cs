using OnlineBookSubscription.Catalog.Data.Repository;
using OnlineBookSubscription.Catalog.Data.Repository.Interfaces;
using OnlineBookSubscription.Catalog.Data.UnitOfWork.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Data.UnitOfWork
{
   public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IGenericRepository<Book> _book;
        private IGenericRepository<Subscription> _subscription;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        public IGenericRepository<Book> Books => _book ??= 
            new GenericRepository<Book>(_context);
        public IGenericRepository<Subscription> Subscription => _subscription ??=
            new GenericRepository<Subscription>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
