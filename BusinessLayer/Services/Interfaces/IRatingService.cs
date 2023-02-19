using BusinessLayer.ViewModels;

namespace BusinessLayer.Services.Interfaces
{
    public interface IRatingService
    {
        Task AddRateAsync(int bookId, AddRateModel model);
    }
}
