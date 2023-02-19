using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hometask2.Controllers
{
    public class ReviewController
    {
        // ### 5. Save a new book.
        [HttpPut("/api/books/{id:int}/review")]
        public async Task<ActionResult> AddReviewAsync(AddReviewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
