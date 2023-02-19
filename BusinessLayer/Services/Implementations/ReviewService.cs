using BusinessLayer.Services.Interfaces;
using BusinessLayer.ViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLayer.Services.Implementations
{
    public class ReviewService: IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddReviewAsync(int bookId, AddReviewModel model)
        {
            var reviewEntity = new Review()
            {
                BookId = bookId,
                Message = model.Message,
                Reviewer = model.Reviewer,
            };

            var review = await _repository.InsertAsync(reviewEntity);
            return review.Id;
        }
    }
}
