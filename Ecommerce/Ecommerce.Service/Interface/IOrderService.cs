using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
   public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetOrders();
        Task<IEnumerable<Orders>> GetByEmail(string email);
        Task<int> Create(CheckoutDto checkoutDto);
        Task<Orders> GetByOrderId(int orderId);

    }
}
