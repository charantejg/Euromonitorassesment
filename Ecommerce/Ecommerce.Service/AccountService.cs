using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interface;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordManagement _passwordManagement;
        private readonly ITokenService _tokenService;

      
        public AccountService(IUnitOfWork unitOfWork,
            IPasswordManagement passwordManagement,
            ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordManagement = passwordManagement;
            _tokenService = tokenService;

        }

        public async Task<LoggedInUser> AddUser(RegisterUser registerUser)
        {
            try
            {
                var user = await _unitOfWork.Users.ExpressionSearch("email", registerUser.Email.ToLower());
                if (user != null && user.Any())
                    return null;

                var appuser = _passwordManagement.CreateHashandSalt(registerUser);
                await _unitOfWork.Users.Add(appuser);
                _unitOfWork.Complete();

                return new LoggedInUser
                {
                    Email = appuser.Email,
                    Token = _tokenService.CreateToken(appuser)
                };
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
           return await _unitOfWork.Users.GetAll();
           
        }

        public async Task<LoggedInUser> Login(LoginUser loginUser)
        {
            var user = await _unitOfWork.Users.ExpressionSearch("email", loginUser.Email.ToLower());

            if (user == null && !user.Any())
                return null;

            if (!_passwordManagement.TryUserLogin(user.First(), loginUser.Password))
                return null;

            return new LoggedInUser
            {
                Email = loginUser.Email,
                Id = user.First().Id,
                FirstName  = user.First().FirstName,
                Token = _tokenService.CreateToken(user.First())
            };
        }
    }
}
