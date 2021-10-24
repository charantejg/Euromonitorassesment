using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
   public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }
    }
}
