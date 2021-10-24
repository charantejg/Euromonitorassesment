using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.DTO
{
   public class CheckoutDto
    {
        
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public List<BookPurchaseDto> BookPurchaeList { get; set; }
    }

    public class BookPurchaseDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ThumbnailPath { get; set; }
        public decimal SubTotal => Price * Quantity;

    }
}
