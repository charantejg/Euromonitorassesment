using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
   public class OrderDetails
    {
        [Required]
        public int  OrderDetailsId { get; set; }
        [ForeignKey("OrderDetails")]
        public int OrdersId { get; set; }
        public string Title { get; set; }
        public string ThumbnailPath { get; set; }
        public int  BookId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public decimal SubTotal { get; set;}

        public static implicit operator List<object>(OrderDetails v)
        {
            throw new NotImplementedException();
        }
    }
}
