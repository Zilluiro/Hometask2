using BusinessLayer.Services.Interfaces;
using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hometask2.Controllers
{
    [Route("api/recommended")]
    public class RecommendationsController: Controller
    {
        private readonly IRecommendationsService _service;

        public RecommendationsController(IRecommendationsService service)
        {
            _service = service;
        }

        // ### 2. Get top 10 books with high rating and number of reviews greater than 10.
        // You can filter books by specifying genre.Order by rating
        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> GetRecommendations(string genre)
        {
            var toTake = 10;
            var minReviews = 2;
            var result = await _service.GetRecommendationsAsync(genre, toTake, minReviews);

            return Ok(result);
        }
    }
}
