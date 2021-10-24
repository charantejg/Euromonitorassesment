using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Data.UnitOfWork.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Application
{
    public class BookService: IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
    
        public BookService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
           return await _unitOfWork.Books.GetAll();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _unitOfWork.Books.GetById(id);
        }

        public async Task<bool> AddBook(Book book)
        {
            throw new System.NotImplementedException();
        }
    }
}