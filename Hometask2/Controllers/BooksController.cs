using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hometask2.Controllers
{
    [Route("api/{controller}")]
    public class BooksController
    {
        // ### 1. Get all books. Order by provided value (title or author)
        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> GetAllBooksAsync(string order)
        {
            throw new NotImplementedException();
        }

        // ### 3. Get book details with the list of reviews
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDetailsModel>> GetBookDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        // ### 4. Delete a book using a secret key. Save the secret key in the config of
        // your application.Compare this key with a query param
        [HttpDelete("{id:int}")]
        public async Task RemoveBookAsync(int id, string secret)
        {
            throw new NotImplementedException();
        }

        // ### 5. Save a new book.
        [HttpPost("save")]
        public async Task AddUpdateBookAsync(AddUpdateBookModel model)
        {
            throw new NotImplementedException();
        }
    }
}
