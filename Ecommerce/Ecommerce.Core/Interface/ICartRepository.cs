using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interface
{
   public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<int> MaxItemFromCart(Cart cart);
    }
}
