using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Ecommerce.Service;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Fake
{
    public class AccountServiceFake : IAccountService
    {
        private readonly List<AppUser> _appUsers;
       


        public AccountServiceFake()
        {
         
             
            _appUsers = new List<AppUser>()
            {
                new AppUser() {Id = 1, Email="test1@test.com", FirstName="Mohan", 
                    LastName="Roy" },
                new AppUser() {Id = 2, Email="test2@test.com", FirstName="Praveen",
                    LastName="Pateel" },
                new AppUser() {Id = 3, Email="test3@test.com", FirstName="Sachin",
                    LastName="Tendulkar" }
            };

          

        }

        
        public Task<LoggedInUser> AddUser(RegisterUser registerUser)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return  _appUsers;
        }

        public async Task<AppUser> GetAllUsersById()
        {
            return (AppUser)_appUsers.Where(x => x.Id == 1);
        }

        public async Task<LoggedInUser> Login(LoginUser loginUser)
        {
            throw new NotImplementedException();

        }
    }
}
