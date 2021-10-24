using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interface
{
   public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        IBookRepository Books { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get;  }
        ICartRepository Cart { get; }
        int Complete();
    }
}
