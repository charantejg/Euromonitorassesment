using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineSubscription.Catalog.UnitTest
{
    public class BookServiceFake: IBookService
    {
        private readonly List<Book> _books;
        public BookServiceFake()
        {
            _books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Let us C",
                    Author = "Yashwant",
                    Isbn = "001",
                    Price = 100.0
                },
                new Book
                {
                    Id = 2,
                    Title = "Python",
                    Author = "John",
                    Isbn = "002",
                    Price = 150.0
                },
                new Book
                {
                    Id = 3,
                    Title = "Design Patterns",
                    Author = "Bob",
                    Isbn = "003",
                    Price = 250.0
                }
            };
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
           return _books;
        }

        public async Task<Book> GetBookById(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }


        public async Task<bool> AddBook(Book book)
        {
            _books.Add(book);
            return true;
        }
    }
}