using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
  public  class Orders
    {
       
        public int OrdersId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalCost { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
