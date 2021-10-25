using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OnlineBookSubscription.Catalog.Api.Controllers;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineSubscription.Catalog.UnitTest
{
    public class TestBookController
    {
        private readonly BookController _controller;
        private readonly IBookService _service;

        public TestBookController()
        {
            _service = new BookServiceFake();
            var config = new MapperConfiguration(opts =>
            {
                opts.CreateMap<Book, BooksDto>();
            });
            var mapper = config.CreateMapper();

            _controller = new BookController(_service, mapper);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
          //Act
          var okResult = _controller.GetAll();

          //Assert
          Assert.IsInstanceOf<List<BooksDto>>(okResult.Result);

        }



      
    }
}