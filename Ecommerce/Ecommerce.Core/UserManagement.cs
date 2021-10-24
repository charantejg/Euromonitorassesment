using Ecommerce.Core.DTO;
using Ecommerce.Core.Interface;
using Ecommerce.Data;
using Ecommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core
{
    public class UserManagement : IUserManagement
    {

        private readonly DataContext _dataContext;
      

        public UserManagement(DataContext _dataContext)
        {

            this._dataContext = _dataContext;
           
        }

       

        public async Task<AppUser> CreateUser(RegisterUser newUser)
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

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();
            return user;
           
        }

      

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<AppUser> TryUserLogin(LoginUser loginUser)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Email == loginUser.Email.ToLower());
            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return null;
                }
            }

            return user;
 
        }

       public async Task<bool> CheckUserExists(string email)
        {
            return await _dataContext.Users.AnyAsync(x => x.Email.Equals(email.ToLower())); ;
        }

    }
}

