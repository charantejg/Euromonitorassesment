using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnlineBookSubscription.Catalog.Data.Repository.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Data.Repository
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context) : base(context)
        {
        }
    }

}
