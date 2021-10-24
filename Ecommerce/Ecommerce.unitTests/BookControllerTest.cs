using AutoMapper;
using Ecommerce.Api.Controllers;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.UnitTests.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ecommerce.UnitTests
{
  public  class BookControllerTest
    {
        BookController _controller;
        BookServiceFake _service;
       

        public BookControllerTest()
        {
            _service = new BookServiceFake();
        }

        [Fact]
        public void DisplayBooks_WhenCalled_ResultsMatchTestData()
        {
            
            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<Book, BooksDto>();
            });
            var mapper = config.CreateMapper();
           
           
            _controller = new BookController(_service, mapper);
                      
            var okResult =  _controller.GetAll();

            //Assert
            var items = Assert.IsType<List<BooksDto>>(okResult.Result);
            Assert.Equal(2, items.Count);
        }

        

    }
}
