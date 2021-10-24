using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookSubscription.Catalog.Domain.Entities
{
   public class Subscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }

    }
}
