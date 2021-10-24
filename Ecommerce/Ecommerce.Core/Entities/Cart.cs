using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
   public class Cart
   {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        [ForeignKey("UserIdCart")]
        public int UserId { get; set; }
        [ForeignKey("BookIdCart")]
        public int BookId { get; set; }
    }
}
