using BusinessLayer.Enumerations;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.ViewModels;
using Hometask2.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Hometask2.Controllers
{
    [Route("api/{controller}")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRatingService _ratingService;
        private readonly SecretsConfiguration _secrets;

        public BooksController(IBookService bookService, IRatingService ratingService,
            IOptions<SecretsConfiguration> secretsConf)
        {
            _bookService = bookService;
            _ratingService = ratingService;
            _secrets = secretsConf.Value;
        }

        // ### 1. Get all books. Order by provided value (title or author)
        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> GetAllBooksAsync(string? order)
        {
            BookOrderEnum enumOrder = BookOrderEnum.Empty;
            if (!string.IsNullOrEmpty(order))
            {
                var normalizedOrderValue = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(order);
                var validation = Enum.TryParse<BookOrderEnum>(normalizedOrderValue, out enumOrder);
                if (!validation)
                    return BadRequest("'Order' parameter is invalid");
            }

            var result = await _bookService.GetBooksOrderedByAsync(enumOrder);
            return Ok(result);
        }

        // ### 3. Get book details with the list of reviews
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDetailsModel>> GetBookDetailsAsync(int id)
        {
            var result = await _bookService.GetBookDetailsAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // ### 4. Delete a book using a secret key. Save the secret key in the config of
        // your application.Compare this key with a query param
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> RemoveBookAsync(int id, string secret)
        {
            if (string.IsNullOrEmpty(secret) || secret != _secrets.AdminPassword)
                return BadRequest("'Secret' parameter is invalid or empty");

            var result = await _bookService.RemoveBookAsync(id);

            if (result)
                return Ok();
            else
                return NotFound();
        }

        // ### 5. Save a new book.
        [HttpPost("save")]
        public async Task<ActionResult<int>> AddUpdateBookAsync(AddUpdateBookModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }

            int bookId = await _bookService.AddUpdateBookAsync(model);
            return Ok(bookId);
        }

        [HttpPut("{id}/rate")]
        public async Task<ActionResult> AddUpdateBookAsync(int id, AddRateModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }

            await _ratingService.AddRateAsync(id, model);
            return Ok();
        }
    }
}
