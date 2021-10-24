using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public BookController(IBookService bookService, IMapper mapper, IConfiguration configuration, IWebHostEnvironment env)
        {
            _bookService = bookService;
            _mapper = mapper;
            _configuration = configuration;
            _env = env;
        }
        
        [HttpGet]
        public async  Task<IEnumerable<BooksDto>> GetAll()
        {
            var books = await _bookService.GetAll();
            IEnumerable<BooksDto> booksDto
                = _mapper.Map<IEnumerable<Book>, IEnumerable<BooksDto>>(books);

           return booksDto;
        }


        [HttpGet("testsecure")]
       public IActionResult TestSecure()
        {
            return Ok("Book Service is reachable when using a token");
        }


    }
}
