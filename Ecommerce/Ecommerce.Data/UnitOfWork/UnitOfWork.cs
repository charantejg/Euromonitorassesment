using Ecommerce.Core.Interface;
using Ecommerce.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IUserRepository Users { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IBookRepository Books { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderDetailRepository OrderDetails { get; private set; }
        public ICartRepository Cart { get; private set; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
            Books = new BookRepository(_context);
            Orders = new OrderRepository(_context);
            OrderDetails = new OrderDetailsRepository(_context);
            Cart = new CartRepository(_context);
           
        }
       
        
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
