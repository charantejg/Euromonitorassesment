using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
      
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            
        }

        public string InvoiceGenerator()
        {
            int maxOrderNumber = 1;
            try
            {
               maxOrderNumber  = GetMaxPK(x => x.OrdersId) + 1;
            }
            catch
            {
                //ignored
            }
            
            var random = new Random();

            return "ODC" + DateTime.Now.ToString("yyyyMM") + 
                "-" + random.Next(00000, 99999) +
                "-" + maxOrderNumber.ToString().PadLeft(4, '0');
        }

    }
}
