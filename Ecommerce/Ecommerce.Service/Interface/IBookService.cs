using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
   public interface IBookService
    {

        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetBookbyId(int id);
        Task<bool> AddBook(Book book);
      
    }
}
