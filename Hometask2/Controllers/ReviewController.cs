using BusinessLayer.Services.Interfaces;
using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hometask2.Controllers
{
    public class ReviewController: Controller
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        // ### 6. Save a review for the book.
        [HttpPut("/api/books/{id:int}/review")]
        public async Task<ActionResult<int>> AddReviewAsync(int id, AddReviewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors);
                return BadRequest(errors);
            }

            var reviewId = await _service.AddReviewAsync(id, model);
            return Ok(reviewId);
        }
    }
}
