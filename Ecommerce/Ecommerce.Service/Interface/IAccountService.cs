using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public interface IAccountService
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<LoggedInUser> AddUser(RegisterUser registerUser);
        Task<LoggedInUser> Login(LoginUser loginUser);


    }
}