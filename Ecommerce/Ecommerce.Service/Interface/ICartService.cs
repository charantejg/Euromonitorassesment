using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
   public interface ICartService
    {
        Task<int> Post(Cart cart);
        Task<CheckoutDto> Get(int userId);
        Task<int> Remove(Cart cart);
        Task<int> GetMaxCartId(Cart cart);
        Task<IEnumerable<Cart>> GetCartItems(int userId);
        void RemoveCartItems(IEnumerable<Cart> carts);

    }
}
