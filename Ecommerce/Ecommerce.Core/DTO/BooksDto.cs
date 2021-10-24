using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.DTO
{
   public class BooksDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Description { get; set; }
        public string ThumbnailPath { get; set; }
        public decimal Price { get; set; }
        
    }
}
