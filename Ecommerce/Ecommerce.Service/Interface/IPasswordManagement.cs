using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;

namespace Ecommerce.Service.Interface
{
    public interface IPasswordManagement
    {
       AppUser CreateHashandSalt(RegisterUser newUser);
        bool TryUserLogin(AppUser user, string password);
    }
}