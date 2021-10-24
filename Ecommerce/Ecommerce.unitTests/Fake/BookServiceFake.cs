using AutoMapper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Fake
{
    public class BookServiceFake : IBookService
    {
        private readonly List<Book> _books;
       

        public BookServiceFake()
        {

            _books = new List<Book>()
            {
                new Book() { BookId=1, BookTitle = "Java", CategoryId = 1, 
                    Description ="Core Java Volume 1", Price = 100, ThumbnailPath = "java.png"},
                new Book() { BookId=1, BookTitle = "Microsoft .NET book", CategoryId = 1,
                    Description ="Advanced Course in .NET", Price = 200, ThumbnailPath = "net.png"}
            };

        }

        public Task<bool> AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return _books;
           
        }

        public async Task<Book> GetBookbyId(int id)
        {
            var book =  _books.Find(x => x.BookId == id);
            return book;
        }
    }
}
