using BusinessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hometask2.Controllers
{
    [Route("api/recommended")]
    public class RecommendationsController
    {
        // ### 2. Get top 10 books with high rating and number of reviews greater than 10.
        // You can filter books by specifying genre.Order by rating
        [HttpGet]
        public async Task<ActionResult<List<BookModel>>> GetRecommendations(string genre)
        {
            throw new NotImplementedException();
        }
    }
}
