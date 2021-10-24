using Ecommerce.Api.Controllers;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Service;
using Ecommerce.UnitTests.Fake;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Ecommerce.UnitTests
{
    public class UserControllerTest
    {
        UserController _fakecontroller;
        IAccountService _fakeservice;


        public UserControllerTest()
        {
            _fakeservice = new AccountServiceFake();
            _fakecontroller = new UserController(_fakeservice);

        }

        [Fact]
        public void GetAllUsers_WhenCalled_ReturnsAllItem()
        {
            //Act
            var okResut = _fakecontroller.GetAllUsers().Result as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<AppUser>>(okResut.Value);
            Assert.Equal(3, items.Count);

        }

       

        public static implicit operator UserControllerTest(UserController v)
        {
            throw new NotImplementedException();
        }
    }
}
