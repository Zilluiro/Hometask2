using BusinessLayer.Services.Interfaces;
using BusinessLayer.ViewModels;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLayer.Services.Implementations
{
    public class RatingService: IRatingService
    {
        private readonly IRatingRepository _repository;

        public RatingService(IRatingRepository repository)
        {
            _repository = repository;
        }

        public async Task AddRateAsync(int bookId, AddRateModel model)
        {
            var ratingEntity = new Rating()
            {
                BookId = bookId,
                Score = model.Score,
            };

            await _repository.InsertAsync(ratingEntity);
        }
    }
}
