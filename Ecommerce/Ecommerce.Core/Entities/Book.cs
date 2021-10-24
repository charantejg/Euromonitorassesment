using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string ThumbnailPath { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }



    }
}
