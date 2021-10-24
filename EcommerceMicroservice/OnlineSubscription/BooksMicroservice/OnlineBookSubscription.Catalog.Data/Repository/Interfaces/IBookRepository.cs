using OnlineBookSubscription.Catalog.Domain.Entities;
using OnlineBookSubscription.Identity.Data.Repository.Interfaces;

namespace OnlineBookSubscription.Catalog.Data.Repository.Interfaces
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        
    }
}
