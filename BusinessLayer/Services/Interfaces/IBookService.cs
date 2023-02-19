using BusinessLayer.Enumerations;
using BusinessLayer.ViewModels;

namespace BusinessLayer.Services.Interfaces
{
    public interface IBookService
    {
        Task<IList<BookModel>> GetBooksOrderedByAsync(BookOrderEnum order);

        Task<BookDetailsModel> GetBookDetailsAsync(int bookId);

        Task<bool> RemoveBookAsync(int bookId);

        Task<int> AddUpdateBookAsync(AddUpdateBookModel model);
    }
}
