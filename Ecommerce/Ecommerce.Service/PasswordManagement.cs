using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.Interface;
using System.Security.Cryptography;
using Ecommerce.Core.DTO;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service { 
    public class PasswordManagement: IPasswordManagement
    {
       
       public AppUser CreateHashandSalt(RegisterUser newUser)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Email = newUser.Email.ToLower(),
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(newUser.Password)),
                PasswordSalt = hmac.Key
            };
            return user;
        }

        public bool TryUserLogin(AppUser user, string password)
        {
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return false;
                }
            }

            return true;

        }
    }
}
