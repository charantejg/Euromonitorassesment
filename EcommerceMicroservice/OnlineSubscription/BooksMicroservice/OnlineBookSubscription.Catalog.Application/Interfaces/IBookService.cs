using OnlineBookSubscription.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookSubscription.Catalog.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetBookById(int id);
        Task<bool> AddBook(Book book);
    }
}