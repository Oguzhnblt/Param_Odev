using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.BookOperation.Command.CreatBook;
using WebApi_Param_Odev.Application.BookOperation.Command.CreatBook;
using WebApi_Param_Odev.Application.BookOperation.Command.DeleteBook;
using WebApi_Param_Odev.Application.BookOperation.Command.UpdateBook;
using WebApi_Param_Odev.Application.BookOperation.Queries.GetBookDetail;
using WebApi_Param_Odev.Application.BookOperation.Queries.GetBooks;
using WebApi_Param_Odev.DBOperations;

namespace WebApi_Param_Odev.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks() // Book listesindeki verileri alma 
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Book listesindeki id si verilen elemanı bulma
        {
            BookDetailViewModel result;
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;
            GetBookDetailQueryValidator cv = new GetBookDetailQueryValidator(); //validator sınıfını calıştırma
            cv.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        //Post
        [HttpPost]// ekleme
        public IActionResult AddBook([FromBody] CreateBookModel newBook)// dönüş degerleri badrequest, ok .. oldugu için IActionResult
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            //try
            //{
            command.Model = newBook;
            CreateBookCommandValidator cv = new CreateBookCommandValidator(); //validator sınıfını calıştırma
            cv.ValidateAndThrow(command); // hatayı yakalayıp catchdeki exceptiona atıyor hata mesajını
            command.Handle();



            return Ok();
        }


        //Put
        [HttpPut("{id}")] //güncelleme
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatedBook;

            UpdateBookCommandValidator cv = new UpdateBookCommandValidator();
            cv.ValidateAndThrow(command);
            command.Handle();


            return Ok();

        }

        [HttpDelete("{id}")] // Silme
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator cv = new DeleteBookCommandValidator(); //validator sınıfını calıştırma
            cv.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }


    }

}