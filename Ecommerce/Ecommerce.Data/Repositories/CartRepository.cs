using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
   public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

       

        public async Task<int> MaxItemFromCart(Cart cart)
        {
            try
            {
                var items = await Find(x => x.UserId == cart.UserId && x.BookId == cart.BookId);
                var maxCartValue = items.Max(x => x.CartId);
                return maxCartValue;
            }
            catch
            {
                return 0;
            }
        }
    }
}
