using AutoMapper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{

    public class BookController : BaseApiController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;


        public BookController(IBookService bookService,
            IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet("DisplayBooks")]
        public async Task<IEnumerable<BooksDto>> GetAll()
        {
            var books = await _bookService.GetAll();
            IEnumerable<BooksDto> booksDto
                = _mapper.Map<IEnumerable<Book>, IEnumerable<BooksDto>>(books);
            return booksDto;
        }


        [HttpGet("{id}")]
        public async Task<BooksDto> GetBookbyId(int id)
        {
            var book =  await _bookService.GetBookbyId(id);
            var booksDto = _mapper.Map<Book, BooksDto>(book);

            return booksDto;
        }


        [Authorize]
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook(Book book)
        {
            var result = await _bookService.AddBook(book);

            if (result)
                return Ok();
            else
                return StatusCode(500, "Error occured when addding Book");
        }


    }
}
