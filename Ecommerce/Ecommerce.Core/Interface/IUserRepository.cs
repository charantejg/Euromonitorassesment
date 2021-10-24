using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interface
{
    public interface IUserRepository: IGenericRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> ExpressionSearch(string property, string searchWord);
       

    }
}
