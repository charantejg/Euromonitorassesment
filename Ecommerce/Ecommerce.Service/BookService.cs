using AutoMapper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Ecommerce.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
       

        public BookService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _config = configuration;
        }

        public async Task<bool> AddBook(Book book)
        {
            //TODO:  upload the image to the wwwroot folder. 
            book.ThumbnailPath = Path.Combine(_config["ImagePath"], book.ThumbnailPath);
            await _unitOfWork.Books.Add(book);
            var result = _unitOfWork.Complete();
            if (result == 1)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _unitOfWork.Books.GetAll();

        }

        public async Task<Book> GetBookbyId(int id)
        {
            return await _unitOfWork.Books.GetById(id);
        }
    }
}
