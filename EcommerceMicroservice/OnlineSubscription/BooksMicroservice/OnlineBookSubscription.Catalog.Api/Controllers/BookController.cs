using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineBookSubscription.Catalog.Application.DTO;
using OnlineBookSubscription.Catalog.Application.Interfaces;
using OnlineBookSubscription.Catalog.Domain.Entities;

namespace OnlineBookSubscription.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
      

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
           
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
