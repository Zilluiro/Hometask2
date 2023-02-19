using BusinessLayer.Services.Interfaces;
using BusinessLayer.ViewModels;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.Implementations
{
    public class RecommendationsService: IRecommendationsService
    {
        private readonly IBookRepository _repository;

        public RecommendationsService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookModel>> GetRecommendationsAsync(string? genre, int toTake = 10, int minReviews = 10)
        {
            var list = _repository.List();

            if (!string.IsNullOrEmpty(genre))
                list = list.Where(x => x.Genre == genre);

            var query = list.Include(x => x.Ratings)
                .Include(x => x.Reviews)
                .Where(x => x.Reviews.Count() >= minReviews)
                .OrderByDescending(x => x.Ratings.Average(x => x.Score))
                .Take(toTake);

            var result = await query.Select(x => new BookModel()
            {
                Id = x.Id,
                Author = x.Author,
                Title = x.Title,

                Rating = x.Ratings.Count > 0 ? Convert.ToDecimal(x.Ratings.Average(r => r.Score)) : 0,
                ReviewsNumber = x.Reviews.Count(),
            }).ToListAsync();

            return result;
        }
    }
}
