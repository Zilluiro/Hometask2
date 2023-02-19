using BusinessLayer.ViewModels;

namespace BusinessLayer.Services.Interfaces
{
    public interface IReviewService
    {
        Task<int> AddReviewAsync(int bookId, AddReviewModel model);
    }
}
