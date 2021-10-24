using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Core.Interface;
using Ecommerce.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Core.Entities;
using AutoMapper;
using Ecommerce.Service;

namespace Ecommerce.Api.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _accountService.GetAllUsers();
            return Ok(users);
        }


        [HttpPost("AddUser")]
        public async Task<ActionResult<LoggedInUser>> AddUser([FromBody] RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest("Email,FirstName and Passwiord are required.Please enter valid data");

            var user = await _accountService.AddUser(registerUser);
            if (user == null)
                return StatusCode(500,"Error occured when creating user");

            return user;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoggedInUser>> Login([FromBody] LoginUser loginUser)
        {
            if (!ModelState.IsValid)
                return BadRequest("Email Id / Password are not in correct format");

            var user = await _accountService.Login(loginUser);

            if (user == null)
                return StatusCode(500, "Email Id or Password is invalid");

            return Ok(user);


        }
    }

}
