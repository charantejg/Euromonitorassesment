using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
              
        public UserRepository(ApplicationContext applicationContext): base(applicationContext)
        {

        }

       

        public async Task<IEnumerable<AppUser>> ExpressionSearch(string property, string searchWord)
        {
            switch (property)
            {
                case "email":
                default:
                    return await Find(x => x.Email.Equals(searchWord));
            }
        }

     
    }

}
