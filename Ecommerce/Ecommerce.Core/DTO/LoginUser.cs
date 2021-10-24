using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Core.DTO
{
    public class LoginUser
    {
       
        [Required, RegularExpression("^(.+)@(.+)$")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
