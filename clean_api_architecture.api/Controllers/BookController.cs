using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clean_api_architecture.core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using clean_api_architecture.infrastructure.Repositories.Implementations;

namespace clean_api_architecture.api.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookRepository bookRepository, ILogger<BookController> logger)
        {
            this._bookRepository = bookRepository;
            this._logger = logger;
        }

        [HttpPost(Name="CreateBook")]
        public async Task<ActionResult<Book>> CreateAsync(Book book)
        {

            await _bookRepository.CreateAsync(book);
            return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        }

        [HttpGet(Name = "GetBooks")]
        public ActionResult<IAsyncEnumerable<Book>> GetBooks()
        {
            try
            {
                IAsyncEnumerable<Book> books = _bookRepository.FindAll();
                if (books == null)
                {
                    return NotFound();
                }
                return Ok(books);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Handle exception {exception}");
                return StatusCode(500, exception);
            }
        }

        [HttpGet("{id}", Name = "GetBook")]
        public async Task<ActionResult<Book>> GetBook(string id)
        {
            try
            {
                Book book = await _bookRepository.FindById(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Handle exception {exception}");
                return StatusCode(500, exception);
            }
        }

        [HttpPut("{id:length(24)}", Name="UpdateBook")]
        public async Task<IActionResult> UpdateBook(string id, Book book)
        {
            Book selectedBook = await _bookRepository.FindById(id);
            if (selectedBook == null)
            {
                return NotFound();
            }
            await _bookRepository.Update(selectedBook, book);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}", Name="DeleteBook")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            Book book = await _bookRepository.FindById(id);

            if (book == null)
            {
                return NotFound();
            }
            await _bookRepository.Remove(book);
            return NoContent();
        }
    }
}