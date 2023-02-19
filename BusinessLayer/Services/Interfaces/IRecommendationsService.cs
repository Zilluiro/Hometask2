using BusinessLayer.ViewModels;

namespace BusinessLayer.Services.Interfaces
{
    public interface IRecommendationsService
    {
        Task<List<BookModel>> GetRecommendationsAsync(string? genre, int toTake = 10, int minReviews = 10);
    }
}
